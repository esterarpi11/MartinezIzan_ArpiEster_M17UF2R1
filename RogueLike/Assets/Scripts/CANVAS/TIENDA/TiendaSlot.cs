using UnityEngine;

public class TiendaSlot : MonoBehaviour
{
    Inventario inventario;
    GameManager gameManager;
    public AudioSource audio;
    private void Start()
    {
        inventario = Inventario.instance;
        gameManager = GameManager.instance;
    }
    public void ComprarArma(Arma arma)
    {
        if (gameManager.buyWeapon(arma))
        {
            audio.Play();
            inventario.Add(arma);
        }
    }
}
