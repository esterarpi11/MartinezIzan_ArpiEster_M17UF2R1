using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TiendaUI : CanvasUI
{
    // Start is called before the first frame update
    void Start()
    {
        _inputs.MainPlayer.Tienda.performed += CanvasActive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CanvasActive(InputAction.CallbackContext obj)
    {
        canvasUI.SetActive(!canvasUI.activeSelf);
    }
}
