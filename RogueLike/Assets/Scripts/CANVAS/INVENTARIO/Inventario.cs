using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 6;
    public static Inventario instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else Destroy(gameObject);
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
