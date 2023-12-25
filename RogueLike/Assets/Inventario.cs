using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario instance;

    private void Awake()
    {
        if (instance != null) return;
        instance = this; 
    }

    public int space = 6;
    public List<Arma> items = new List<Arma> ();

    public void Add (Arma arma)
    {
        if(items.Count < space)
        {
            items.Add(arma);
        }
    }
}
