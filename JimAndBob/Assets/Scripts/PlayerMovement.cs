using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Rigidbody2D body;

    [SerializeField] private Animator animator;

    private Vector2 moveDirection;

    private bool movingDown;
    private bool movingUp;
    private bool movingRight;
    private bool movingLeft;

    private float moveX;
    private float moveY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Inputs();

        if (moveY < 0)
        {
            movingDown = true;
            movingUp = false;
            animator.SetBool("movingDown", movingDown);
            animator.SetBool("movingUp", movingUp);
        }

        if (moveY == 0)
        {
            movingDown = false;
            movingUp = false;
            animator.SetBool("movingDown", movingDown);
            animator.SetBool("movingUp", movingUp);
        }

        if (moveY > 0)
        {
            movingDown = false;
            movingUp = true;
            animator.SetBool("movingDown", movingDown);
            animator.SetBool("movingUp", movingUp);
        }

        if (moveX > 0)
        {
            movingRight = true;
            movingLeft = false;
            animator.SetBool("walkingRight", movingRight);
            animator.SetBool("walkingLeft", movingLeft);
        }

        if (moveX == 0)
        {
            movingRight = false;
            movingLeft = false;
            animator.SetBool("walkingRight", movingRight);
            animator.SetBool("walkingLeft", movingLeft);
        }

        if (moveX < 0)
        {
            movingRight = false;
            movingLeft = true;
            animator.SetBool("walkingRight", movingRight);
            animator.SetBool("walkingLeft", movingLeft);
        }



    }

    void FixedUpdate()
    {
        Move();

    }

    void Inputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        body.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
