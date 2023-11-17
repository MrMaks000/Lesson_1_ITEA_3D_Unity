using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2.0f;

    private float rotationX = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(Vector3.up * mouseX * sensitivity);       
        rotationX -= mouseY * sensitivity;
        if (rotationX > 360f) rotationX -= 360f;
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
