using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpPower = 2.0f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private bool isDoubleJumping = false;
    [SerializeField] private bool canDoubleJump = false;

    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && isGrounded == true)
        {
            body.AddForce(jumpPower * Vector3.up, ForceMode.Impulse);
            isGrounded = false;

            if (canDoubleJump == true)
            {
                if (isDoubleJumping == true && isGrounded == false)
                {
                    isGrounded = true;
                    isDoubleJumping = false;
                }
                StartCoroutine(ResetDoubleJumpAfterDelay(4f));
            }
        }
    }

    private IEnumerator ResetDoubleJumpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isDoubleJumping = false;
        canDoubleJump = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _) == true)
        {
            isGrounded = true;
            isDoubleJumping = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<DoubleJumpObjact>(out _) == true)
        {
            isDoubleJumping = true;
            canDoubleJump = true;
        }
    }

    public bool GetCanDoubleJump()
    {
        return canDoubleJump;
    }
}
