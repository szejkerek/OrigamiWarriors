using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  private MovementSchemes input = null;
  //private Vector2 moveVector2D = Vector2.zero;
  private Vector3 moveVector3D = Vector3.zero;
  private Rigidbody rb = null;
  
  public float moveSpeed = 5.0f;


  private void Awake()
  {
    input = new MovementSchemes();
    rb = GetComponent<Rigidbody>();
  }

  private void OnEnable()
  {
    input.Enable();
    input.Player3D.Movement.performed += OnMovementPerformed;
    input.Player3D.Movement.canceled += OnMovementCancelled;
  }

  private void OnDisable()
  {
    input.Disable();
    input.Player3D.Movement.performed -= OnMovementPerformed;
    input.Player3D.Movement.canceled -= OnMovementCancelled;
  }

  private void FixedUpdate()
  {
    Debug.Log(moveVector3D);
    rb.velocity = moveVector3D * moveSpeed;
  }

  // function to be called when we press appropriate button
  private void OnMovementPerformed(InputAction.CallbackContext keyValue)
  {
    //moveVector2D = keyValue.ReadValue<Vector2>();
    moveVector3D = keyValue.ReadValue<Vector3>();
  }

  private void OnMovementCancelled(InputAction.CallbackContext keyValue)
  {
    //moveVector2D = Vector2.zero;
    moveVector3D = Vector3.zero;
  }
}
