using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float AccelPower;
    [SerializeField] private float Speed;

    private Rigidbody RB;

    //Lateral movement
    private InputAction MoveInput;
    private Vector2 MoveValue; 
    private Vector2 LateralMoveValue;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
        MoveInput = InputSystem.actions.FindAction("Move");

        //Verif
        if(RB != null)
        {
            Debug.Log("Player_RB INITIALIZE");   
        }
        else
        {
            Debug.Log("Player_RB NULL");
        }
    }

    private void FixedUpdate()
    {
        if(Speed > 0)
        {
            Move(); 
        }
        else
        {
            Debug.Log("WARNING : Speed equal 0 or is negative;");
        }

  
    }

    private void Move()
    {
        //SETUP
        MoveValue = MoveInput.ReadValue<Vector2>();
        LateralMoveValue = new Vector2(MoveValue.x * AccelPower, 0f);
        Debug.Log("LateralMoveValue_New_Value : x." + LateralMoveValue.x + " y." + LateralMoveValue.y);

        //Action
        RB.AddForce(LateralMoveValue, ForceMode.VelocityChange);

        //Limit
        if(RB.linearVelocity.magnitude > Speed)
        {
            Vector2 ClampVelocity = RB.linearVelocity.normalized * Speed;
            RB.linearVelocity = ClampVelocity;
        }
    }
}