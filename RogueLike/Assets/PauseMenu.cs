using GameInputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;   
    public GameObject pauseMenu;
    public GameInput _inputs;
    public GameObject player;

    private void Awake()
    {
        _inputs = new GameInput();
        _inputs.MainPlayer.Enable();

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else Destroy(gameObject);
    }
    private void Start()
    {
        _inputs.MainPlayer.Pausa.performed += PauseActive;
    }
    public void clickButton(int n)
    {      
        switch (n)
        {
            case 1:
                Time.timeScale = 1f;
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                break;
            default:
                GameManager.instance.chooseScene(n);
                break;
        }
    }
    public void PauseActive(InputAction.CallbackContext obj)
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(!pauseMenu.activeSelf);    
    }
}
