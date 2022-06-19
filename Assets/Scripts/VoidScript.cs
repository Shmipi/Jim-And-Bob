using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidScript : MonoBehaviour
{

    [SerializeField] private GameController gc;

    [SerializeField] private GameObject spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gc.TakeDamage();
            collision.gameObject.transform.position = spawnPoint.transform.position;

        }
    }

}
