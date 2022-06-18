using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{

    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite pressedSprite;

    [SerializeField] private GameController gc;
    [SerializeField] private GameObject door;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
        door.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Crate")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = pressedSprite;
            gc.levelComplete = true;
            door.SetActive(false);
            
            //Debug.Log("pressed!" + gc.levelComplete);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Crate")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
            gc.levelComplete = false;
            door.SetActive(true);

            //Debug.Log("unpressed!" + gc.levelComplete);
        }
    }
}
