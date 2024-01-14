using UnityEngine;

public class TiendaSlot : MonoBehaviour
{
    Inventario inventario;
    GameManager gameManager;
    private void Start()
    {
        inventario = Inventario.instance;
        gameManager = GameManager.instance;
    }
    public void ComprarArma(Arma arma)
    {
        if(gameManager.buyWeapon(arma)) inventario.Add(arma);
    }
}
