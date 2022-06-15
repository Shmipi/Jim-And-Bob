using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private GameController gc;
    [SerializeField] private SpriteRenderer spriteRenderer;


    [SerializeField] private Sprite neutral;
    [SerializeField] private Sprite orange;
    [SerializeField] private Sprite blue;

    [SerializeField] private GameObject orangeLight;
    [SerializeField] private GameObject blueLight;

    private BoxCollider2D[] colliders;
    private BoxCollider2D halfCollider;

    private GameObject player;

    private bool isOrange;
    private bool isBlue;

    private Animator animator;

    private void Start()
    {
        gc = gc.GetComponent<GameController>();

        player = GameObject.FindGameObjectWithTag("Player");

        if(gameObject.tag == "TopWall")
        {
            colliders = gameObject.GetComponents<BoxCollider2D>();
            halfCollider = colliders[1];
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), halfCollider);

            animator = gameObject.GetComponent<Animator>();
            animator.SetBool("isOrange", false);
            animator.SetBool("isBlue", false);
        }
    }

    private void setWhite()
    {
        //spriteRenderer.color = Color.white;
        spriteRenderer.sprite = neutral;
        isBlue = false;
        isOrange = false;
        orangeLight.SetActive(false);
        blueLight.SetActive(false);

        if(gameObject.tag == "TopWall")
        {
            animator.SetBool("isOrange", false);
            animator.SetBool("isBlue", false);
        }
    }

    private void setOrange()
    {
        //spriteRenderer.color = Color.red;
        spriteRenderer.sprite = orange;
        isBlue = false;
        isOrange = true;
        orangeLight.SetActive(true);

        if(gameObject.tag == "TopWall")
        {
            animator.SetBool("isOrange", true);
        }
    }

    private void setBlue()
    {
        //spriteRenderer.color = Color.blue;
        spriteRenderer.sprite = blue;
        isBlue = true;
        isOrange = false;
        blueLight.SetActive(true);

        if(gameObject.tag == "TopWall")
        {
            animator.SetBool("isBlue", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "OrangeProjectile" && isOrange == false && isBlue == false)
        {
            if (gc.orangeWall != null)
            {
                gc.orangeWall.setWhite();
                gc.orangeWall = null;
            }
            setOrange();
            gc.orangeWall = this;

        } else if (collision.transform.tag == "BlueProjectile" && isBlue == false && isOrange == false)
        {
            if (gc.blueWall != null)
            {
                gc.blueWall.setWhite();
                gc.blueWall = null;
            }
            setBlue();
            gc.blueWall = this;
        }
    }
}
