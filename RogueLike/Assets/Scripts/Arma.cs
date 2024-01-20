using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventario/Arma")]
public class Arma : ScriptableObject
{
    new public string name = "arma";
    public Sprite icon = null;
    public float damage = 0f;
    public int price = 0;
    public int numProyectiles = 1;
    public float velocidadProyectil = 10f;
    public GameObject proyectil = null;
    Weapon arma;

    public virtual void Use()
    {
        arma.arma = this;
    }
}
