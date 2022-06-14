using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionCubeBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameController gc;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gc.orangeWall != null && gc.blueWall != null)
        {
            if (collision.gameObject == gc.orangeWall.gameObject)
            {
                //flytta till blå
                gameObject.transform.position = gc.blueWall.transform.GetChild(0).position;
            }

            if (collision.gameObject == gc.blueWall.gameObject)
            {
                //flytta till orange
                gameObject.transform.position = gc.orangeWall.transform.GetChild(0).position;
            }
        }
    }
}
