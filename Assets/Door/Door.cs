using UnityEngine;

public class Door : Interactable
{
    private bool isOpen = false;

    private bool isTransitioning = false;

    // private readonly float speed = 2.0f;
    private float interpolate = 0.00025f;

    private Vector3 startPosition;

    private void Start()
    {
        this.startPosition = this.transform.position;
    }

    public override void Interact()
    {
        this.isOpen = !this.isOpen;
        this.interpolate = 0.00025f;
        this.isTransitioning = true;
    }

    private void Update()
    {
        if (this.isTransitioning)
        {
            var goalPosition = this.isOpen
                ? new Vector3(
                    this.startPosition.x,
                    this.startPosition.y + 3.90f,
                    this.startPosition.z
                )
                : this.startPosition;
            ;

            var distance = Vector3.Distance(this.transform.position, goalPosition);

            if (distance > 0)
            {
                this.transform.position = Vector3.Lerp(
                    this.transform.position,
                    goalPosition,
                    this.interpolate
                );

                this.interpolate += 0.00025f;
            }
            else
            {
                if (!this.isOpen)
                {
                    this.transform.position = goalPosition;
                }

                this.isTransitioning = false;
            }
        }
    }
}
