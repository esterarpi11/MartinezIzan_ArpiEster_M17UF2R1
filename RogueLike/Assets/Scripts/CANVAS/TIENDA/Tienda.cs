using UnityEngine;

public class Tienda : MonoBehaviour
{
    public static Tienda instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else Destroy(gameObject);
    }
}
