using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerLook : MonoBehaviour
{
    public float xRotationBounds = 80.0f;
    public float xSensitivity = 30.0f;
    public float ySensitivity = 30.0f;
    public Vector3 yRotation;

    public Camera Camera { get; private set; }
    private float xRotation = 0.0f;

    private void Awake()
    {
        this.Camera = GetComponent<Camera>();
    }

    public void ProcessLook(Vector2 input)
    {
        Debug.Log(input);
        var mouseX = input.x;
        var mouseY = input.y;

        // Calculate camera rotation for looking up and down.
        var xRotation = this.xRotation - (mouseY * Time.deltaTime * this.ySensitivity);
        this.xRotation = Mathf.Clamp(xRotation, -this.xRotationBounds, this.xRotationBounds);
        this.Camera.transform.localRotation = Quaternion.Euler(this.xRotation, 0, 0);

        // For left and right, simply rotate the player.
        // TODO: Why do we need to keep a record of the transform value in this.yRotation?
        this.yRotation += mouseX * Time.deltaTime * this.xSensitivity * Vector3.up;
        this.transform.Rotate(this.yRotation);
    }
}
