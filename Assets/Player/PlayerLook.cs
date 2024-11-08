using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float xSensitivity = 30.0f;
    public float ySensitivity = 30.0f;

    public Camera playerCamera;

    private float xRotation = 0.0f;

    private float yRotation = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ProcessLook(Vector2 input)
    {
        var mouseX = input.x * Time.deltaTime * this.xSensitivity;
        var mouseY = input.y * Time.deltaTime * this.ySensitivity;

        this.yRotation += mouseX;
        this.xRotation -= mouseY;
        this.xRotation = Mathf.Clamp(this.xRotation, -90f, 90f);

        this.playerCamera.transform.rotation = Quaternion.Euler(this.xRotation, this.yRotation, 0);
        this.transform.rotation = Quaternion.Euler(0, this.yRotation, 0);
    }
}
