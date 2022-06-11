using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] GameObject raycastOrigin;
    [SerializeField] Animator animator;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.GetComponent<Transform>().position, raycastOrigin.GetComponent<Transform>().TransformDirection(Vector2.up), 10f);

        if (hit.transform.gameObject.tag == "Player")
        {
            animator.SetTrigger("Active");
            Debug.Log("Shot!");
        }
    }
}
