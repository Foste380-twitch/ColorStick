using UnityEngine;
using UnityEngine.InputSystem;

public class CapacityManager : MonoBehaviour
{
    //Wall Slide
    private InputAction WSInput;

    private void Awake()
    {
        WSInput = InputSystem.actions.FindAction("Wall Slide");
        WSInput.started += WallSlide;

        AwakeDbg();
    }

    private void AwakeDbg()
    {
        if(WSInput != null)
        {
            Debug.Log("Player_Capacity_WSInput INITIALIZE");
        }
        else
        {
            Debug.Log("Player_Capacity_WSInput NULL");
        }
    }

    private void WallSlide(InputAction.CallbackContext context)
    {
        
    }
}