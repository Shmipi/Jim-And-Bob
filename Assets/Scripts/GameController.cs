using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int health = 3;

    public Wall orangeWall = null;
    public Wall blueWall = null;

    private void Start()
    {
        health = 3;
    }

    private void TakeDagame()
    {
        health -= 1;
    }

}
