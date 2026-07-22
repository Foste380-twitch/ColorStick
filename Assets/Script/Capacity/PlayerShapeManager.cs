using UnityEngine;

public class PlayerShapeManager : MonoBehaviour
{
    [Header("Initial")]
    public Mesh InitialeMesh;
    public Collider InitialCollider;
    [Header("WallSlide")]
    public Mesh WSMesh;
    public Collider WSCollider;

    private Mesh ActualMesh;
    private Collider ActualCollider;

    private void Awake()
    {
        ActualCollider = InitialCollider;
        ActualMesh = GetComponent<MeshFilter>().mesh;

        AwakeDbg();
    }

    private void AwakeDbg()
    {
        if (ActualCollider != null)
        {
            Debug.Log("Player_Actual_Collider INITIALIZE");
        }
        else
        {
            Debug.Log("Player_Actual_Collider NULL");
        }

        if (ActualMesh != null)
        {
            Debug.Log("Player_Actual_Mesh INITIALIZE");
        }
        else
        {
            Debug.Log("Player_Actual_Mesh NULL");
        }
    }

    public void SetNewShape(Mesh NewMesh, Collider NewCollider)
    {
        if (ActualMesh != NewMesh)
        {
            MeshFilter.mesh = NewMesh;
            ActualMesh = NewMesh;
        }
        else
        {
            Debug.Log("WARNING : Player Old and New MESH are same");
        }

        if (ActualCollider != NewCollider)
        {
            ActualCollider.enabled = false;
            NewCollider.enabled = true;
        }
        else
        {
            Debug.Log("WARNING : Player Old and New COLLIDER are same");
        }
    }
}