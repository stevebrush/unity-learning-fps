using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour
{
    public float gravity = -9.8f;
    private bool isGrounded;
    public float jumpHeight = 3.0f;
    public float speed = 5.0f;

    private CharacterController controller;
    private Vector3 velocity;

    private void Start()
    {
        this.controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        this.isGrounded = this.controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        var direction = Vector3.zero;
        direction.x = input.x;
        direction.z = input.y; // the y-axis on the controller translates to the z-axis in-game.

        // First, move the character according to the input direction.
        this.controller.Move(this.speed * Time.deltaTime * transform.TransformDirection(direction));

        // Finally, move the character along the y-axis according to the current pull of gravity.
        this.velocity.y += this.gravity * Time.deltaTime;

        if (this.isGrounded && this.velocity.y < 0)
        {
            this.velocity.y = this.gravity;
        }

        this.controller.Move(this.velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (this.isGrounded)
        {
            // Equation to calculator jump velocity.
            // @see https://www.youtube.com/watch?v=LRHjI1h3IvU
            this.velocity.y =
                (-this.gravity * Time.deltaTime / 2.0f)
                + Mathf.Sqrt(-2 * this.gravity * this.jumpHeight);
        }
    }
}
