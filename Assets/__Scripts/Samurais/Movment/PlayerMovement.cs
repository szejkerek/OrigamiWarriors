using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput = Vector2.zero;
    private CharacterController characterController;
    public float speed = 5f;

    private MovementSchemes input = null;
    private void Awake()
    {
        input = new MovementSchemes();
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        input.Player3D.Enable();
        input.Player3D.Movement.performed += OnMovementPerformed;
        input.Player3D.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        input.Player3D.Disable();
        input.Player3D.Movement.performed -= OnMovementPerformed;
        input.Player3D.Movement.canceled -= OnMovementCancelled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector3>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext context)
    {
        moveInput = Vector3.zero;
    }

    private void Update()
    {
        if (moveInput != Vector2.zero)
        {
            Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
            characterController.Move(move * speed * Time.deltaTime);
        }
    }
}
