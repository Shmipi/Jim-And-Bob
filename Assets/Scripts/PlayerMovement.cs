using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Rigidbody2D body;

    [SerializeField] private Animator animator;

    [SerializeField] private GameController gc;

    private Vector2 moveDirection;

    private bool movingDown;
    private bool movingUp;
    private bool movingRight;
    private bool movingLeft;

    private float moveX;
    private float moveY;


    private void Start()
    {
        gc = gc.GetComponent<GameController>();
    }

    void Update()
    {
        if(gc.isPaused == false)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "TurretProjectile")
        {
            gc.TakeDagame();
        }

        if(gc.orangeWall != null && gc.blueWall != null)
        {
            Debug.Log("touched wall");

            if(collision.gameObject == gc.orangeWall.gameObject)
            {
                Debug.Log("orange to blue");
                //flytta till blå
                //gameObject.transform.position = gc.blueWall.transform.position;
                gameObject.transform.position = gc.blueWall.transform.GetChild(0).position;
            }

            if (collision.gameObject == gc.blueWall.gameObject)
            {
                Debug.Log("blue to orange");
                //flytta player till orange
                //gameObject.transform.position = gc.orangeWall.transform.position;
                //gameObject.transform.position = gc.orangeWall.GetComponentInChildren<Transform>().position;
                gameObject.transform.position = gc.orangeWall.transform.GetChild(0).position;
            }
        }
    }
}
