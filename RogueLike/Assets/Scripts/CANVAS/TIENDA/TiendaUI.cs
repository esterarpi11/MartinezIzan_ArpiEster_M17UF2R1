using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TiendaUI : CanvasUI
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        _inputs.MainPlayer.Tienda.performed += CanvasActive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CanvasActive(InputAction.CallbackContext obj)
    {
        if(gameManager.openTienda()) canvasUI.SetActive(!canvasUI.activeSelf);
    }
}
