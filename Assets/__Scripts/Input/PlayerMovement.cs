using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  private MovementSchemes input = null;
  private Vector3 moveVector3D = Vector3.zero;
  private Rigidbody rb = null;
  private Animator animator = null;

  // adjust the velocity from the editor
  [SerializeField] private float moveSpeed = 5;
  // adjust the gravity for this specific model
  [SerializeField] private float gravityFactor = 250;
  // jumping factor
  [SerializeField] private float jumpingFactor = 50;

  private void Awake()
  {
    input = new MovementSchemes();
    rb = GetComponent<Rigidbody>();
    animator = GetComponent<Animator>();
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

    rb.AddForce(Vector3.down * gravityFactor, ForceMode.Acceleration); // force of gravity
  }

  // function to be called when we press appropriate button
  private void OnMovementPerformed(InputAction.CallbackContext keyValue)
  {
    moveVector3D = keyValue.ReadValue<Vector3>();
    //rb.AddForce(moveVector3D * moveSpeed, ForceMode.Force);

    // Add the animations based on the direction in which we are moving
    if (moveVector3D != Vector3.zero)
    {
      animator.SetFloat("Z", 1);
      animator.SetFloat("X", moveVector3D.x);
      transform.rotation = Quaternion.LookRotation(moveVector3D);
    } 
    else
    {
      animator.SetFloat("X", moveVector3D.x);
      animator.SetFloat("Z", moveVector3D.z);
    }
      
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
