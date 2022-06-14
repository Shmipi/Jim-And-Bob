using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestruction : MonoBehaviour
{

    private GameController gc;


    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        GameObject turret = GameObject.FindGameObjectWithTag("Turret");
        Physics2D.IgnoreCollision(turret.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gc.orangeWall != null && gc.blueWall != null)
        {
            if (collision.gameObject == gc.orangeWall.gameObject)
            {
                gameObject.transform.position = gc.blueWall.transform.GetChild(0).position;

                //gameObject.GetComponent<Rigidbody2D>().velocity = gc.blueWall.transform.GetChild(0).GetComponent<Transform>().up * -10f;

                if(gc.blueWall.transform.position.x > gc.blueWall.transform.GetChild(0).position.x)
                {
                    //this is a side wall
                    gameObject.GetComponent<Rigidbody2D>().velocity = gc.blueWall.transform.GetChild(0).GetComponent<Transform>().right * -10f;
                }
                else
                {
                    //this is a top wall
                    gameObject.GetComponent<Rigidbody2D>().velocity = gc.orangeWall.transform.GetChild(0).GetComponent<Transform>().up * -10f;
                }

            }
            else if (collision.gameObject == gc.blueWall.gameObject)
            {
                gameObject.transform.position = gc.orangeWall.transform.GetChild(0).position;

                //gc.orangeWall.GetComponentInChildren<Transform>().up; // funkar också
                //gameObject.GetComponent<Rigidbody2D>().velocity = gc.orangeWall.transform.GetChild(0).GetComponent<Transform>().up * -10f;

                if (gc.orangeWall.transform.position.x > gc.orangeWall.transform.GetChild(0).position.x)
                {
                    //this is a side wall
                    gameObject.GetComponent<Rigidbody2D>().velocity = gc.orangeWall.transform.GetChild(0).GetComponent<Transform>().right * -10f;
                }
                else
                {
                    //this is a top wall
                    gameObject.GetComponent<Rigidbody2D>().velocity = gc.orangeWall.transform.GetChild(0).GetComponent<Transform>().up * -10f;
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

        //Destroy(gameObject);
    }
}
