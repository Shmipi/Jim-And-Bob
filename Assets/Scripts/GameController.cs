using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int health = 3;

    public Wall orangeWall = null;
    public Wall blueWall = null;

    [SerializeField] GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        health = 3;
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void TakeDagame()
    {
        health -= 1;
    }

}
