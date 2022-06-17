using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayWallScript : MonoBehaviour
{

    private GameObject player;

    private BoxCollider2D[] colliders;
    private BoxCollider2D halfCollider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        colliders = gameObject.GetComponents<BoxCollider2D>();
        halfCollider = colliders[1];
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), halfCollider);
    }
}
