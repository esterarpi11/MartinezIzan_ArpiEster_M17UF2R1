using UnityEngine;
using UnityEngine.UI;

public class InventarioSlot : MonoBehaviour
{
    public Image icon;
    Arma arma;
    Weapon weapon;

    private void Start()
    {
        weapon = Weapon.instance;
    }
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
            weapon.arma = arma.Use();
        }
    }
}
