using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : Canvas
{
    public static Inventario instance;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }
    public List<Arma> items = new List<Arma>();
    public void Add(Arma arma)
    {
        if (items.Count < space)
        {
            items.Add(arma);
        }
        if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
    }
}
