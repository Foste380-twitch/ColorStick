using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Run")]
    [SerializeField] private float AccelPower;
    [SerializeField] private float Speed;
    [Header("Jump")]
    [SerializeField] private float JumpPower;

    private Rigidbody RB;

    //Lateral movement
    private InputAction MoveInput;
    private Vector2 MoveValue; 
    private Vector2 LateralMoveValue;

    //Jump
    private InputAction JumpInput;
    private Vector2 JumpVector;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
        MoveInput = InputSystem.actions.FindAction("Move");
        JumpInput = InputSystem.actions.FindAction("Jump");

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



        //Limit
        if(RB.linearVelocity.magnitude > Speed)
        {
            Vector2 ClampVelocity = RB.linearVelocity.normalized * Speed;
            RB.linearVelocity = ClampVelocity;
        }
        //Action
        else
        {
          RB.AddForce(LateralMoveValue, ForceMode.VelocityChange);
        }
    }
    private void jump()
    {
        bool JumpInputValue = JumpInput.ReadValue<bool>();

        if(JumpInputValue == true)
        {
            JumpVector = new Vector2(0f,JumpPower); 
            RB.AddForce(JumpVector, ForceMode.Impulse);
        }
    }
}

