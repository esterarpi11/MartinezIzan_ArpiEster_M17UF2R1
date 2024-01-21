using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutorial;
    void Awake()
    {
    }

    public void clickButton(int n)
    {
        switch (n)
        {
            case 2: 
                tutorial.SetActive(!tutorial.activeSelf);
                mainMenu.SetActive(!mainMenu.activeSelf);
                break;
            default:
                SceneManager.LoadScene(1);
                break;
        }
    }
}
