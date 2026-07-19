using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float AttAnimDelay;
    [SerializeField] private float ReuseDelay;
    [SerializeField] private float UseDelay;
    [SerializeField] private Collider AttZone;

    private InputSystem AttInput;
    private bool CanAtt = true;
    
    private void OnAwake()
    {
        
        RB = GetComponent<RigidBody>();
        AttInput = InputSystem.ation.FindAction("Attack");
        AttInput.started = Action;

        if (AttInput != null)
        {
            Debug.Log("Player_AttInput INITIALISE");
        }
        else
        {
            Debug.Log("Payer_AttInput NULL");
        }
    }

    private void Action(InputAction.CallbackContext context)
    {
        if (CanAtt)
        {
            if (AttZone != null)
            {
                AttZone.Enable = true;
                CanAtt = false;
                yield return new WaitForSeconds(UseDelay);
                AttZone.Enable = false;
                Renew();
            }
            else
            {
                Debug.Log("ERROR : Player_AttZone NULL");
            }            
        }
    }
    private void Renew()
    {
        yield return new WaitForSeconds(ReuseDelay);
        CanAtt = true;
    }
}