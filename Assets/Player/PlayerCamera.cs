using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public new Camera camera;

    void FixedUpdate()
    {
        this.camera.transform.position = this.transform.position;
    }
}
