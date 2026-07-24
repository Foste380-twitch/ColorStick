using UnityEngine;
using UnityEngine.InputSystem;

public class CapacityManager : MonoBehaviour
{
    private PlayerMove Move;

    //Wall Slide
    private InputAction WSInput;
    private bool WSActive = false;
    private PlayerShapeManager ShapeManager;
    public bool OnWall = false;
    private bool WallHere = false;

    //Setup
    private void Awake()
    {
        ShapeManager = GetComponent<PlayerShapeManager>();
        Move = GetComponent<PlayerMove>();

        WSInput = InputSystem.actions.FindAction("Wall Slide");
        WSInput.started += WSStarted;
        WSInput.canceled += WSEnded;

        AwakeDbg();
    }

    private void Update()
    {
        WSShape();
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
    private void WSShape()
    {
        //Change Shape (quand on vient d'appuyer)
        if (WSInput.WasPressedThisFrame() && WallHere)
        {
            WSActive = true;
            Debug.Log("Wall_Slide_Status : ACTIVE");
            ShapeManager.SetNewShape(ShapeManager.WSMesh, ShapeManager.WSCollider);
        }

        //Quand on relâche la touche (ou qu'on n'est plus sur le mur)
        if (WSInput.WasReleasedThisFrame() || !WallHere)
        {
            if (WSActive)
            {
                WSActive = false;
                Debug.Log("Wall_Slide_Status : INACTIVE");
                ShapeManager.SetNewShape(ShapeManager.InitialeMesh, ShapeManager.InitialCollider);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Wall Slide"))
        {
            WallHere = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Wall Slide"))
        {
            WallHere = false;
            Move.RB.useGravity = true;
            OnWall = false;
        }
    }

    private void WSStarted(InputAction.CallbackContext context)
    {
        if (WallHere)
        {
            Move.RB.useGravity = false;
            OnWall = true;
        }
    }

    private void WSEnded(InputAction.CallbackContext context)
    {
        if (OnWall)
        {
            Move.RB.useGravity = true;
            OnWall = false;
        }
    }
}