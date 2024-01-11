using GameInputs;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class CanvasUI : MonoBehaviour
{
    public Transform inventarioSlots;
    public GameObject canvasUI;
    public GameInput _inputs;

    private void Awake()
    {
        _inputs = new GameInput();
        _inputs.MainPlayer.Enable();
    }
    public abstract void CanvasActive(InputAction.CallbackContext obj); 
}
