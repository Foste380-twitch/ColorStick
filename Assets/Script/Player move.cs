using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private InputAction lateralMoveInput;

    private void Awake()
    {
        lateralMoveInput = InputSystem.actions.FindAction("Move");
            }

    private void Update()
    {
        Vector2 lateralMoveValue = lateralMoveInput.ReadValue<Vector2>();
        transform.Translate(lateralMoveValue.x * Time.deltaTime, 0f, 0f);
    }
}