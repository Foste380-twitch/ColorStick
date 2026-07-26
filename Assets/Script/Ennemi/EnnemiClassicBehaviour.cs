using UnityEngine;
using System.Collections;

public class EnnemiClassicBehaviour : MonoBehaviour
{
    [SerializeField] private int Color;

    public int HP;
    public string ID;

    private string StrColor;

    private void Awake()
    {
        AwakeDbg();
    }
    private void FixedUpdate()
    {
        DeadManager();
    }

    private void AwakeDbg()
    {
        if ((HP != null) && (HP != 0))
        {
            Debug.Log("Ennemi_" + ID + "_HP INITIATE");
        }
        else if (HP == 0)
        {
            Debug.Log("Ennemi_" + ID + "_HP 0");
        }
        else
        {
            Debug.Log("Ennemi_" + ID + "_HP NULL");
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("TriggerAttack"))
        {
            Hit();
        }
    }

    private void Hit()
    {
        if (Color == 0)
        {
            HP -= 1;
        }
    }

    private void DeadManager()
    {
        if (HP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}