using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float AttAnimDelay;
    [SerializeField] private float ReuseDelay;
    [SerializeField] private float UseDelay;
    [SerializeField] private Collider AttZone;

    private InputAction AttInput;
    private bool CanAtt = true;
    
    private void Awake()
    {
        AttInput = InputSystem.actions.FindAction("Attack");
        AttInput.started += Action;

        if (AttInput != null)
        {
            Debug.Log("Player_AttInput INITIALISE");
        }
        else
        {
            Debug.Log("Payer_AttInput NULL");
        }
    }

    private void Action(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StartCoroutine(ActionCoroutine());
        }
    }
    private IEnumerator ActionCoroutine()
    {
        if (CanAtt)
        {
            if (AttZone != null)
            {
                AttZone.enabled = true;
                CanAtt = false;
                Debug.Log("Player_AttZone ON");
                yield return new WaitForSeconds(UseDelay);
                Debug.Log("Player_AttZone OFF");
                AttZone.enabled = false;
                StartCoroutine(Renew());
            }
            else
            {
                Debug.Log("ERROR : Player_AttZone NULL");
            }            
        }
        else
        {
            Debug.Log ("Player can not Attack : CanAtt = false");
        }
    }
    private IEnumerator Renew()
    {
        Debug.Log("Player Attack begin de renewing");
        yield return new WaitForSeconds(ReuseDelay);
        CanAtt = true;
        Debug.Log("Player Attack Renew");
    }
}