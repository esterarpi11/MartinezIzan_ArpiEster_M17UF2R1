using UnityEngine;

public class TiendaSlot : MonoBehaviour
{
    Inventario inventario;
    public void ComprarArma(Arma arma)
    {
        Debug.Log("Añadir" + arma);
        //inventario.Add(arma);
    }
}
