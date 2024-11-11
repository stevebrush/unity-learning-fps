using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private GameObject playerHead;

    private readonly float distance = 3.0f;
    private PlayerInputManager inputManager;

    [SerializeField]
    private LayerMask mask;

    private void Start()
    {
        this.inputManager = GetComponent<PlayerInputManager>();
    }

    private void Update()
    {
        var ray = new Ray(this.playerHead.transform.position, this.playerHead.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * this.distance);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, this.distance, this.mask))
        {
            if (hitInfo.collider.TryGetComponent<Interactable>(out var interactable))
            {
                if (this.inputManager.OnFoot.Interact.triggered)
                {
                    interactable.Interact();
                }
            }
        }
    }
}
