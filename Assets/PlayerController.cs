using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{

    public string moveStatus = "idle";
    public bool walkByDefault = true;
    public float gravity = 20.0f;
    //Movement speeds
    public float jumpSpeed = 8.0f;
    public float runSpeed = 10.0f;
    public float walkSpeed = 4.0f;
    public float turnSpeed = 250.0f;
    public float moveBackwardsMultiplier = 0.75f;
    //Internal vars to work with
    private float speedMultiplier = 0.0f;
    private bool grounded = false;
    private Vector3 moveDirection = Vector3.zero;
    private bool isWalking = false;
    private bool jumping = false;
    private bool mouseSideButton = false;
    private CharacterController controller;

    void Awake()
    {
        //Get CharacterController
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Set idle animation
        moveStatus = "idle";
        isWalking = walkByDefault;
        // Hold "Run" to run, or walk if walkByDefault is false.
        if (Input.GetAxis("Run") != 0)
        {
            isWalking = !walkByDefault;
        }
        // Only allow movement and jumps while grounded

        if (grounded)
        {
            //if the player is steering with the right mouse button, A/D strafe instead of turn.
            if (Input.GetMouseButton(1))
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            }
            else
            {
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            }
            //Auto-move button pressed
            if (Input.GetButtonDown("Toggle Move"))
            {
                mouseSideButton = !mouseSideButton;
            }
            //player moved or otherwise interrupted the auto-move.
            if (mouseSideButton && (Input.GetAxis("Vertical") != 0 || Input.GetButton("Jump")) || (Input.GetMouseButton(0) && Input.GetMouseButton(1)))
            {
                mouseSideButton = false;
            }
        }
    }
}
