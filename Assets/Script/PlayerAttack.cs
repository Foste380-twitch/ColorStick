using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float AttAnimDelay;
    [SerializeField] private float ReuseDelay;
    [SerializeField] private float useDelay;

    private RigidBody RB;
    private Collider AttZone;
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
            
        }
    }
}