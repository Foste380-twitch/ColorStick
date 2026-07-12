using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float Speed;

    private Rigidbody RB;

    //Lateral movement
    private InputAction lateralMoveInput;
    private Vector2 lateralMoveValue; 

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
        //Verif
        if(RB != null)
        {
            Debug.Log("Player_RB INITIALIZE");   
        }
        else
        {
            Debug.Log("Player_RB NULL");
        }

        lateralMoveInput = InputSystem.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        lateralMoveValue = lateralMoveInput.ReadValue<Vector2>();
        transform.Translate(lateralMoveValue.x * Time.deltaTime * Speed, 0f, 0f);
    }
}