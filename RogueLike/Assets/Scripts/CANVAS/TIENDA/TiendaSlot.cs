using UnityEngine;

public class TiendaSlot : MonoBehaviour
{
    Inventario inventario;
    public void ComprarArma(Arma arma)
    {
        Debug.Log("A�adir" + arma);
        //inventario.Add(arma);
    }
}
