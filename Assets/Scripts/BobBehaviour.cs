using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobBehaviour : MonoBehaviour
{
    [SerializeField] private Transform portalGun;

    [SerializeField] private GameObject orangeBob;
    [SerializeField] private GameObject blueBob;

    [SerializeField] private GameObject orangeProjectile;
    [SerializeField] private GameObject blueProjectile;

    private bool orange = true;

    private Vector2 lookDirection;
    private float lookAngle;

    [SerializeField] private float speed = 4.5f;

    [SerializeField] GameObject target;

    private void Awake()
    {
        transform.position = target.GetComponent<Transform>().position;
    }

    private void Start()
    {
        orangeBob.GetComponent<SpriteRenderer>().enabled = true;
        blueBob.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.GetComponent<Transform>().position, step);

        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
        
    }

    private void FireBullet()
    {
        if(orange == true)
        {
            GameObject firedBullet = Instantiate(orangeProjectile, portalGun.position, portalGun.rotation);
            firedBullet.GetComponent<Rigidbody2D>().velocity = portalGun.up * 10f;
            orange = false;
            orangeBob.GetComponent<SpriteRenderer>().enabled = false;
            blueBob.GetComponent<SpriteRenderer>().enabled = true;
        } else
        {
            GameObject firedBullet = Instantiate(blueProjectile, portalGun.position, portalGun.rotation);
            firedBullet.GetComponent<Rigidbody2D>().velocity = portalGun.up * 10f;
            orange = true;
            orangeBob.GetComponent<SpriteRenderer>().enabled = true;
            blueBob.GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }
}
