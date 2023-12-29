using UnityEngine.InputSystem;

public class InventarioUI : CanvasUI
{
    Canvas canvas;
    InventarioSlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        canvas = Canvas.instance;
        canvas.onItemChangedCallback += UpdateUI;
        _inputs.MainPlayer.Inventario.performed += CanvasActive;
    }

    // Update is called once per frame
    void Update()
    {
        slots = inventarioSlots.GetComponentsInChildren<InventarioSlot>();
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < canvas.items.Count)
            {
                slots[i].AddArma(canvas.items[i]);
            }
        }
    }

    public override void CanvasActive(InputAction.CallbackContext obj)
    {
        canvasUI.SetActive(!canvasUI.activeSelf);
    }
}
