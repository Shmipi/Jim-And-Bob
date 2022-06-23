using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int health = 3;

    public Wall orangeWall = null;
    public Wall blueWall = null;

    public bool isPaused;
    public bool levelComplete;

    [SerializeField] GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        isPaused = false;
        health = 3;
        Time.timeScale = 1;
        levelComplete = false;
        orangeWall = null;
        blueWall = null;

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Cursor.visible = true;
        }

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

    public void TakeDamage()
    {
        health -= 1;
    }

}
