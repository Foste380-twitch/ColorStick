using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Run")]
    [SerializeField] private float AccelPower;
    [SerializeField] private float Speed;
    [SerializeField] private float Break;
    [Header("Jump")]
    [SerializeField] private float JumpPower;
    [SerializeField] private float ModularJumpTime;

    private Rigidbody RB;

    //Lateral movement
    private InputAction MoveInput;
    private Vector2 MoveValue; 
    private Vector2 LateralMoveValue;

    //Jump
    private InputAction JumpInput;
    private Vector2 JumpVector;
    private bool CanJump = false;

    private void Awake()
    {
        //Setup physics
        RB = GetComponent<Rigidbody>();
        //Setup Movement
        MoveInput = InputSystem.actions.FindAction("Move");
        JumpInput = InputSystem.actions.FindAction("Jump");
        JumpInput.started += Jump;

        //Verif
        if(RB != null)
        {
            Debug.Log("Player_RB INITIALIZE");   
        }

        else
        {
            Debug.Log("Player_RB NULL");
        }

        if(JumpInput != null)
        {
            Debug.Log("Player_Jump INITIALIZE");   
        }
        else
        {
            Debug.Log("Player_Jump NULL");
        }

        if(AttInput != null)
        {
            Debug.Log("Player_Att INITIALIZE");   
        }
        else
        {
            Debug.Log("Player_Att NULL");
        }
    }

    private void FixedUpdate()
    {
        if(Speed <= 0)
        {
            Debug.Log("WARNING : Speed equal 0 or is negative;");
        }
        Move(); 
    }

    private void OnTriggerEnter(Collider Zone)
    {
        if(Zone.CompareTag("CZ-Jump"))
        {
            Debug.Log("Jump Enable");
            CanJump = true;
        }
    }

    private void OnTriggerExit(Collider zone)
    {
        if (zone.compareTag("CZ-Jump"))
        {
            Debug.Log("Jump Desable");
            CanJump = false;
        }
    }

    private void Move()
    {
        //SETUP
        MoveValue = MoveInput.ReadValue<Vector2>();
        LateralMoveValue = new Vector2(MoveValue.x * AccelPower, 0f);
        //Debug.Log("LateralMoveValue_New_Value : x." + LateralMoveValue.x + " y." + LateralMoveValue.y);
        
        if(MoveValue.x != 0)
        {
            //Limit
            if(Mathf.Abs(RB.linearVelocity.x) > Speed)
            {
                Vector2 ClampVelocity = new  Vector2(RB.linearVelocity.normalized.x * Speed, RB.linearVelocity.y);
                RB.linearVelocity = ClampVelocity;
            }
            //Action
            else
            {
                RB.AddForce(LateralMoveValue, ForceMode.VelocityChange);
            }  
        }
        //Break
        else if(RB.linearVelocity.x != 0)
        {
            if(Mathf.Abs(RB.linearVelocity.x) >= Break)
            {
                Vector2 BreakVector = new Vector2(RB.linearVelocity.normalized.x * Break * -1, 0f);
                RB.AddForce(BreakVector, ForceMode.VelocityChange);
            }
            else
            {
                Vector2 BreakVector = new Vector2(RB.linearVelocity.x * -1, 0f);
                RB.AddForce(BreakVector, ForceMode.VelocityChange);
            }
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump press");
        if(CanJump)
        {
            JumpVector = new Vector2(0f, JumpPower);            RB.AddForce(JumpVector, ForceMode.Impulse);
            CanJump = false;
        }
    }
}

