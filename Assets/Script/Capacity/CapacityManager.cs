using UnityEngine;
using UnityEngine.InputSystem;

public class CapacityManager : MonoBehaviour
{
    //Wall Slide
    private InputAction WSInput;
    private bool WSActive = false;
    private PlayerShapeManager ShapeManager;

    //Setup
    private void Awake()
    {
        WSInput = InputSystem.actions.FindAction("Wall Slide");

        AwakeDbg();
    }

    private void Update()
    {
        WallSlide();
    }

    //Setup Debug
    private void AwakeDbg()
    {
        if (WSInput != null)
        {
            Debug.Log("Player_Capacity_WSInput INITIALIZE");
        }
        else
        {
            Debug.Log("Player_Capacity_WSInput NULL");
        }
    }

    //Action
    private void WallSlide()
    {
        if (WSInput.triggered)
        {
            WSActive = true;
            Debug.Log("Wall_Slide_Status : ACTIVE");
            ShapeManager.SetNewShape(ShapeManager.WSMesh, ShapeManager.WSCollider);
        }
        else
        {
            WSActive = false;
            Debug.Log("Wall_Slide_Status : INACTIVE");
            ShapeManager.SetNewShape(ShapeManager.InitialeMesh, ShapeManager.InitialCollider);
        }
    }
}