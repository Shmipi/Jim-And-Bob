using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextLevelScript : MonoBehaviour
{
    [SerializeField] int levelToLoad;
    [SerializeField] private GameController gc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (gc.levelComplete == true)
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
}
