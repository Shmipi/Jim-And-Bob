using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{

    [SerializeField] private Color defaultColor;
    [SerializeField] private Color pressedColor;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Crate")
        {
            gameObject.GetComponent<SpriteRenderer>().color = pressedColor;
            Debug.Log("pressed!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Crate")
        {
            gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
            Debug.Log("unpressed!");
        }
    }
}
