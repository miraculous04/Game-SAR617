using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameInput inputManager;
    [SerializeField] private bool isCrouch;
    

    CharacterController playerController;
    Animator playerAnimator;
    Rigidbody playerRB;

    float moveHorizontally;
    float moveVertically;
    Vector3 _motion;
    

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
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

       // Playig the player animtions as soon as you get the input from ther user.
        playerAnimator.SetFloat("inputHorizontal", moveHorizontally);
        playerAnimator.SetFloat("inputVertical", moveVertically);

       

        Crouch(inputManager.crouch);
        
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

    
}
