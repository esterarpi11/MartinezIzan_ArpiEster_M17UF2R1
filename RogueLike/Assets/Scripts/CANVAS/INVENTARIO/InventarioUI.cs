using UnityEngine.InputSystem;

public class InventarioUI : CanvasUI
{
    Inventario inventario;
    InventarioSlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventario = Inventario.instance;
        inventario.onItemChangedCallback += UpdateUI;
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
            if (i < inventario.items.Count)
            {
                slots[i].AddArma(inventario.items[i]);
            }
        }
    }

    public override void CanvasActive(InputAction.CallbackContext obj)
    {
        canvasUI.SetActive(!canvasUI.activeSelf);
    }
}
