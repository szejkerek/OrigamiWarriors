using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  private MovementSchemes input = null;
  private Vector3 moveVector3D = Vector3.zero;
  private Rigidbody rb = null;
  
  // adjust the velocity from the editor
  public float moveSpeed = 5.0f;
  // adjust the gravity for this specific model
  public float gravityFactor = 9.81f;
  // jumping factor
  public float jumpingFactor = 50f;

  private void Awake()
  {
    input = new MovementSchemes();
    rb = GetComponent<Rigidbody>();
  }

  private void OnEnable()
  {
    input.Player3D.Enable();

    input.Player3D.Movement.performed += OnMovementPerformed;
    input.Player3D.Movement.canceled += OnMovementCancelled;

    input.Player3D.Jump.performed += OnJump;
  }

  private void OnDisable()
  {
    input.Player3D.Disable();

    input.Player3D.Movement.performed -= OnMovementPerformed;
    input.Player3D.Movement.canceled -= OnMovementCancelled;

    input.Player3D.Jump.performed -= OnJump;
  }

  private void FixedUpdate()
  {
    //Debug.Log(moveVector3D);
    rb.velocity = moveVector3D * moveSpeed;

    rb.AddForce(Vector3.down * gravityFactor, ForceMode.Acceleration); // force fo gravity
  }

  // function to be called when we press appropriate button
  private void OnMovementPerformed(InputAction.CallbackContext keyValue)
  {
    moveVector3D = keyValue.ReadValue<Vector3>();
    //rb.AddForce(moveVector3D * moveSpeed, ForceMode.Force);
  }

  private void OnMovementCancelled(InputAction.CallbackContext keyValue)
  {
    moveVector3D = Vector3.zero;
  }

  private void OnJump(InputAction.CallbackContext keyValue)
  {
    rb.AddForce(Vector3.up * jumpingFactor, ForceMode.Impulse);
  }
}
