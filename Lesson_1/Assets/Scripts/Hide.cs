using System.Collections;
using UnityEngine;

public class Hide : MonoBehaviour
{
    [SerializeField] GameObject dubleJumpObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerMove>(out _) == true)
        {
            dubleJumpObject.SetActive(false);
            StartCoroutine(ResetAfterDelay(6f));
        }
    }

    private IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dubleJumpObject.SetActive(true);        
    }
}
