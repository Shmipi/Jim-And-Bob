using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject turret = GameObject.FindGameObjectWithTag("Turret");
        Physics2D.IgnoreCollision(turret.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
