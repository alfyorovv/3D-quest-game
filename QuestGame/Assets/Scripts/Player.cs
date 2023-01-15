using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 5;
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        Sprint();
        Jumping();
    }

    private void Movement()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalDirection + transform.right * horizontalDirection;
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1) * speed;

        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
    }

    private void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
            speed += 3;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            speed -= 3;
    }

   
    private void Jumping()
    {
        if (CheckIfGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        }
    }

    //Checking vertical speed to check if grounded
    bool CheckIfGrounded()
    {
        if(rb.velocity.y != 0)
            return false;
        else
            return true;
    }

}
