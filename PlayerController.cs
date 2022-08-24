using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
     
    public float moveSpeed;
    //public Rigidbody theRB;
    public float jumpForce;
    public CharacterController controller;

    public float gravityScale;
    public float rotationSpeed;
  
   

    public Animator anim;

    public float knockBackForce;
    public float knockBackTime;
    public float knockBackCounter;

    private Vector3 movementDirection;


    void Start()
    {
        

        //theRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        //theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        //if (Input.GetButtonDown("Jump")) {

        //theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);

        // moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);


        if (knockBackCounter <= 0)
        {

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            movementDirection.Normalize();

            transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);


            }

            if (controller.isGrounded)
            {
                movementDirection.y = 0f;
              
            } 

        }
        movementDirection.y = movementDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(movementDirection * moveSpeed * Time.deltaTime);

        knockBackCounter -= Time.deltaTime;







        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

        

       

        }

    public void knockBack(Vector3 direction)
    {

        knockBackCounter = knockBackTime;

        movementDirection = direction * knockBackForce;
        movementDirection.y = knockBackForce;

    }

   


}

