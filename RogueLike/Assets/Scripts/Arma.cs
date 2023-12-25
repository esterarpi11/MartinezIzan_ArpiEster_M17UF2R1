using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventario/Arma")]
public class Arma : ScriptableObject
{
    new public string name = "arma";
    public Sprite icon = null;
    public float damage = 0f;

}
