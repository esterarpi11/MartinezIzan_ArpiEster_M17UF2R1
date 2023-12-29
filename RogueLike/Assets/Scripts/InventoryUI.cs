using GameInputs;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    public Transform inventarioSlots;
    public GameObject inventarioUI;
    Inventario inventario;
    InventarioSlot[] slots;
    private GameInput _inputs;

    private void Awake()
    {
        _inputs = new GameInput();
        _inputs.MainPlayer.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        inventario = Inventario.instance;
        inventario.onItemChangedCallback += UpdateUI;

        slots = inventarioSlots.GetComponentsInChildren<InventarioSlot>();

        _inputs.MainPlayer.Inventario.performed += InventarioActive;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void InventarioActive(InputAction.CallbackContext obj)
    {
        inventarioUI.SetActive(!inventarioUI.activeSelf);
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if( i < inventario.items.Count)
            {
                slots[i].AddArma(inventario.items[i]);
            }
        }
    }
}
