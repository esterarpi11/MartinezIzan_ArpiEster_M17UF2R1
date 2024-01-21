using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameManager gameManager;
    public GameObject mainMenu;
    public GameObject tutorial;
    void Awake()
    {
        gameManager = GameManager.instance;
    }

    public void clickButton(int n)
    {
        switch (n)
        {
            case 2: 
                tutorial.SetActive(!tutorial.activeSelf);
                mainMenu.SetActive(!mainMenu.activeSelf);
                break;
            case -1:
                Application.Quit();
                break;
            default:
                SceneManager.LoadScene(n);
                break;
        }
    }
}
