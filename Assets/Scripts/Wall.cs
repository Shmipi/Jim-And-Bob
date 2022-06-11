using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [SerializeField] private GameController gc;
    [SerializeField] private SpriteRenderer spriteRenderer;
    

    private bool isOrange;
    private bool isBlue;

    private void Start()
    {
        gc = gc.GetComponent<GameController>();
    }

    private void setWhite()
    {
        spriteRenderer.color = Color.white;
        isBlue = false;
        isOrange = false;
    }

    private void setOrange()
    {
        spriteRenderer.color = Color.red;
        isBlue = false;
        isOrange = true;
    }

    private void setBlue()
    {
        spriteRenderer.color = Color.blue;
        isBlue = true;
        isOrange = false;
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
