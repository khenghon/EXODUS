using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerControls controls;
    private CharacterController controller;
    private float movesSpeed = 12f;
    private float gravity = -9.81f*2;
    private float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;

    private Vector3 velocity;
    private Vector3 move;

    public GameObject body;
    // Update is called once per frame
    //void Update()
    //{
    //    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    //    if(isGrounded && velocity.y < 0)
    //    {
    //        velocity.y = -2f;
    //    }

    //    if(Input.GetButtonDown("Jump") && isGrounded)
    //    {
    //        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    //    }

    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");

    //    Vector3 move = transform.right * x + transform.forward * z;

    //    controller.Move(move * speed * Time.deltaTime);

    //    velocity.y += gravity * Time.deltaTime;

    //    controller.Move(velocity * Time.deltaTime);
    //}
    private void Awake()
    {
        //PlayerControls playerInputActions = new PlayerControls();
        //playerInputActions.Player.Enable();
        //playerInputActions.Player.Jump.performed += Jump;

        controls = new PlayerControls();
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Grav();
        PlayerMovement();
        Jump();
    }
    private void Grav()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void PlayerMovement()
    {
        move = controls.Player.Move.ReadValue<Vector2>();

        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(movement * movesSpeed * Time.deltaTime);
    }
    private void Jump()
    {
        if (isGrounded && controls.Player.Jump.triggered)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    //public void Jump(InputAction.CallbackContext context)
    //{
    //    if (isGrounded && context.performed)
    //    {
    //        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //    }

    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");

    //    Vector3 move = transform.right * x + transform.forward * z;

    //    controller.Move(move * moveSpeed * Time.deltaTime);

    //    velocity.y += gravity * Time.deltaTime;

    //    controller.Move(velocity * Time.deltaTime);
    //}
}
