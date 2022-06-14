using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreakScript : MonoBehaviour
{

    [SerializeField] private float startHealth = 3f;
    private float health;

    private void Start()
    {
        health = startHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Object.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "TurretProjectile")
        {
            health -= 1;
        }
    }

}
