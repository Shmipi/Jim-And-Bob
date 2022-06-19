using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{

    [SerializeField] GameObject LevelSelectPane;
    [SerializeField] GameObject ButtonPane;
    [SerializeField] GameObject CreditsPane;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlaySandbox()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelSelect()
    {
        LevelSelectPane.SetActive(true);
        ButtonPane.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void BackButton()
    {
        LevelSelectPane.SetActive(false);
        ButtonPane.SetActive(true);
    }

    public void Credits()
    {
        ButtonPane.SetActive(false);
        CreditsPane.SetActive(true);
    }

    public void CreditBackButton()
    {
        ButtonPane.SetActive(true);
        CreditsPane.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
