using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private PlayerInput.OnFootActions onFoot;
    private PlayerLook look;
    private PlayerMotor motor;

    private void Awake()
    {
        this.playerInput = new();
        this.onFoot = this.playerInput.OnFoot;

        this.look = GetComponent<PlayerLook>();
        this.motor = GetComponent<PlayerMotor>();

        this.onFoot.Jump.performed += ctx => this.motor.Jump();
    }

    private void OnEnable()
    {
        this.onFoot.Enable();
    }

    private void OnDisable()
    {
        this.onFoot.Disable();
    }

    private void Update()
    {
        this.motor.ProcessMove(onFoot.Move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        this.look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
}
