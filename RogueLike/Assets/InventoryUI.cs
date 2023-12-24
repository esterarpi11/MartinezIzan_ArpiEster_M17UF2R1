using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUI()
    {

    }
}
