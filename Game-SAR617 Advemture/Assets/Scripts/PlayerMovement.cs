using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public GameInput inputManager;
    [SerializeField] private bool isCrouch;
    [SerializeField] private float playerSpeed;
    float moveHorizontally;
    float moveVertically;
    Vector3 _motion;

    
    CharacterController playerController;
    Animator playerAnimator;
    

    

    [Header("Jump")]
    [SerializeField] private bool isJump;
    [SerializeField] private float stepDown;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;
    [SerializeField] private float control;
    [SerializeField] private float dampTime;
    [SerializeField] private Vector3 velocity;

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
       
    }

    private void Start()
    {
        Cursor.visible= false;
        Cursor.lockState = CursorLockMode.Locked;
    }

  
    private void Update()
    {
        // Getting user input using the input axis method.
        moveHorizontally = Input.GetAxis("Horizontal");
        moveVertically = Input.GetAxis("Vertical");

       // Playing the player animtions as soon as you get the input from ther user.
        playerAnimator.SetFloat("inputHorizontal", moveHorizontally);
        playerAnimator.SetFloat("inputVertical", moveVertically);

        Crouch(inputManager.crouch);
        Running(inputManager.run);
        
    }

    void OnAnimatorMove()
    {
        //To get the last evaluated frame of the player.
        _motion += playerAnimator.deltaPosition;
    }

    void FixedUpdate()
    {
        playerController.Move(_motion);
        _motion = Vector3.zero;

        if (isJump)
        {
            AirUpdate();
        }
        else
        {
            OnGround();
        }
    }

    // To make the player crouch!
    public void Crouch(KeyCode button)
    {
        if(Input.GetKey(button))
        {
            //when hit the keycode it crouch and when you hit the second time it stops crouching
            isCrouch = !isCrouch;
        }

        if(Input.GetKey(button))
        {
            playerAnimator.SetBool("crouch", isCrouch);
        }
    }

    public void Running(KeyCode button)
    {
        if(Input.GetKeyDown(button))
        {
            playerSpeed = 3.1f;
            playerAnimator.SetBool("Run", true);
        }

        if (Input.GetKeyUp(button))
        {
            playerSpeed = 1.4f;
            playerAnimator.SetBool("Run", false);
        }
    }

    void OnGround()
    {
        Vector3 stepForward = _motion * playerSpeed;
        Vector3 stepDownAmount = Vector3.down * stepDown;

        playerController.Move(stepForward + stepDownAmount);
        _motion = Vector3.zero;

        Jump(inputManager.jumping);
    }

    void AirUpdate()
    {
        velocity.y -= gravity * Time.fixedDeltaTime;

        Vector3 displacement = velocity * Time.fixedDeltaTime;
        displacement += CalculateControl();

        playerController.Move(displacement);
        isJump = !playerController.isGrounded;
        _motion = Vector3.zero;
        playerAnimator.SetBool("Jump", isJump);
    }

    Vector3 CalculateControl()
    {
        return ((transform.forward * moveVertically) + (transform.right * moveHorizontally)) * (control / 100); 
    }

    public void Jump(KeyCode button)
    {
        if (Input.GetKeyDown(button))
        {
            if (!isJump)
            {
                isJump = true;
                velocity = playerAnimator.velocity * dampTime * playerSpeed;
                velocity.y = Mathf.Sqrt(2 * gravity * jumpHeight);
                playerAnimator.SetBool("Jump", true);
            }
        }
    }
}
