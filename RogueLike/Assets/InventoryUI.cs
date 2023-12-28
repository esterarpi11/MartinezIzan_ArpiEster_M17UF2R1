using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventario inventario;
    // Start is called before the first frame update
    void Start()
    {
        inventario = Inventario.instance;
        //inventario.onItemChangedCallBack += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUI()
    {

    }
}
