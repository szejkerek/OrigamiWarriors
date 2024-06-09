using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  private MovementSchemes input = null;
  private Vector3 moveVector3D = Vector3.zero;
  private Rigidbody rb = null;
  private Animator animator = null;
  [SerializeField] private float moveSpeed = 5;
  [SerializeField] private float gravityFactor = 250;

  private void Awake()
  {
    input = new MovementSchemes();
    rb = GetComponent<Rigidbody>();
    //animator = GetComponent<Animator>();
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

  private void FixedUpdate()
  {
    rb.velocity = moveVector3D * moveSpeed;
    rb.AddForce(Vector3.down * gravityFactor, ForceMode.Acceleration);
  }

  private void OnMovementPerformed(InputAction.CallbackContext keyValue)
  {
    moveVector3D = keyValue.ReadValue<Vector3>();
    if (moveVector3D != Vector3.zero)
    {
     // animator.SetFloat("Z", 1);
      //animator.SetFloat("X", moveVector3D.x);
      //transform.rotation = Quaternion.LookRotation(moveVector3D);
    } 
    else
    {
      //animator.SetFloat("X", moveVector3D.x);
      //animator.SetFloat("Z", moveVector3D.z);
    }
      
  }

    private void OnMovementCancelled(InputAction.CallbackContext keyValue) => moveVector3D = Vector3.zero;
}
