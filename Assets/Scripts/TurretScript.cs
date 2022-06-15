using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    [SerializeField] private GameObject turret1;
    [SerializeField] private GameObject turret2;

    [SerializeField] private GameObject turretProjectile;

    [SerializeField] private float startup = 0.5f;
    [SerializeField] private float cooldown = 0.3f;

    private bool fired1;
    private bool shooting;

    [SerializeField] GameObject raycastOrigin;
    [SerializeField] Animator animator;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip alert;
    [SerializeField] AudioClip shot;

    [SerializeField] private GameObject lineRender;
    private LineRenderer lr;

    private void Awake()
    {
        lr = lineRender.GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.GetComponent<Transform>().position, raycastOrigin.GetComponent<Transform>().TransformDirection(Vector2.up), 10f);

        lr.SetPosition(0, raycastOrigin.transform.position);
        lr.SetPosition(1, hit.point);

        if (hit.transform.gameObject.tag == "Player")
        {

            if(shooting == false)
            {
                audioSource.PlayOneShot(alert);
            }

            if (fired1 == false)
            {
                PlayAnimation();
                Invoke("FireBullet", startup);
                shooting = true;
            }
        }
    }

    private void PlayAnimation()
    {
        animator.SetTrigger("Active");
    }

    private void FireBullet()
    {
        if(fired1 == false)
        {
            GameObject firedBullet = Instantiate(turretProjectile, turret1.GetComponent<Transform>().position, turret1.GetComponent<Transform>().rotation);
            firedBullet.GetComponent<Rigidbody2D>().velocity = turret1.GetComponent<Transform>().up * 10f;
            audioSource.PlayOneShot(shot);
            fired1 = true;
            Invoke("FireBullet", cooldown);

        } else
        {
            GameObject firedBullet = Instantiate(turretProjectile, turret2.GetComponent<Transform>().position, turret2.GetComponent<Transform>().rotation);
            firedBullet.GetComponent<Rigidbody2D>().velocity = turret2.GetComponent<Transform>().up * 10f;
            audioSource.PlayOneShot(shot);
            fired1 = false;
            shooting = false;
        }
    }
}
