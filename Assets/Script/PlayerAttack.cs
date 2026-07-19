using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float AttAnimDelay;
    [SerializeField] private float ReuseDelay;
    [SerializeField] private float UseDelay;
    [SerializeField] private Collider AttZone;

    private InputAction AttInput;
    private bool CanAtt = true;
    
    private void OnAwake()
    {
        AttInput = InputSystem.actions.FindAction("Attack");
        AttInput.started += Action;

        if (AttInput != null)
        {
            Debug.Log("Player_AttInput INITIALISE");
        }
        else
        {
            Debug.Log("Payer_AttInput NULL");
        }
    }

    private IEnumerator Action(InputAction.CallbackContext context)
    {
        if (CanAtt)
        {
            if (AttZone != null)
            {
                AttZone.enabled = true;
                CanAtt = false;
                yield return new WaitForSeconds(UseDelay);
                AttZone.enabled = false;
                Renew();
            }
            else
            {
                Debug.Log("ERROR : Player_AttZone NULL");
            }            
        }
    }
    private IEnumerator Renew()
    {
        yield return new WaitForSeconds(ReuseDelay);
        CanAtt = true;
    }
}