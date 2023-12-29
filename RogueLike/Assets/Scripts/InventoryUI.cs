using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform inventarioSlots;
    Inventario inventario;
    InventarioSlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventario = Inventario.instance;
        inventario.onItemChangedCallBack += UpdateUI;

        slots = inventarioSlots.GetComponentsInChildren<InventarioSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if( i < inventario.items.Count)
            {
                slots[i].AddItem(inventario.items[i]);
            }
        }
    }
}
