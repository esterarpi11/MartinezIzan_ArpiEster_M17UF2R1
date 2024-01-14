using UnityEngine;
using UnityEngine.UI;

public class InventarioSlot : MonoBehaviour
{
    public Image icon;
    Arma arma;

    public void AddArma(Arma newArma)
    {
        arma = newArma;

        icon.sprite = arma.icon;
        icon.enabled = true;
    }
    public void UseArma()
    {
        if(arma != null)
        {
            arma.Use();  
        }
    }
}
