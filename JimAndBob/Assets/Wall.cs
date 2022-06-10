using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color color; //för testning

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "OrangeProjectile")
        {
            color = Color.red;
            spriteRenderer.color = color;

        } else if(collision.transform.tag == "BlueProjectile")
        {
            color = Color.blue;
            spriteRenderer.color = color;
        }
    }
}
