using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] GameObject raycastOrigin;
    [SerializeField] Animator animator;

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
            animator.SetTrigger("Active");
            Debug.Log("Shot!");
        }
    }
}
