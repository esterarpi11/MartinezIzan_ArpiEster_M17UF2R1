using UnityEngine;

public class TiendaSlot : MonoBehaviour
{
    Inventario inventario;
    GameManager gameManager;
    private void Start()
    {
        inventario = GetComponent<Inventario>();
        gameManager = GetComponent<GameManager>();
    }
    public void ComprarArma(Arma arma)
    {
        inventario.Add(arma);
    }
}
