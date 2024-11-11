using UnityEngine;

public class Door : Interactable
{
    public override void Interact()
    {
        Debug.Log("Interacted with " + this.gameObject.name);
    }
}
