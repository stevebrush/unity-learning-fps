using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    public PlayerInput.OnFootActions OnFoot { get; private set; }
    private PlayerLook look;
    private PlayerMotor motor;

    private void Awake()
    {
        this.playerInput = new();
        this.OnFoot = this.playerInput.OnFoot;

        this.look = GetComponent<PlayerLook>();
        this.motor = GetComponent<PlayerMotor>();

        this.OnFoot.Jump.performed += ctx => this.motor.Jump();
    }

    private void OnEnable()
    {
        this.OnFoot.Enable();
    }

    private void OnDisable()
    {
        this.OnFoot.Disable();
    }

    private void Update()
    {
        this.motor.ProcessMove(OnFoot.Move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        this.look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
    }
}
