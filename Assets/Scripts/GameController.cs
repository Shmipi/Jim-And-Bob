using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int health = 3;

    public Wall orangeWall = null;
    public Wall blueWall = null;

    public bool isPaused;

    [SerializeField] GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        isPaused = false;
        health = 3;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
            isPaused = true;
            Cursor.visible = true;
            gameOverPanel.SetActive(true);
        }
    }

    public void TakeDagame()
    {
        health -= 1;
    }

}
