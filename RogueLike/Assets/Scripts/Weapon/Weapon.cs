using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject proyectilPrefab;  // Asigna el prefab del proyectil en el Inspector
    public float velocidadProyectil = 10f;

    // Update is called once per frame
    void Update()
    {
        // Detecta clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            DispararProyectil();
        }
    }

    void DispararProyectil()
    {
        // Obtiene la posici�n del rat�n en el mundo
        Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posicionRaton.z = 0f;  // Asegura que la coordenada Z sea cero

        // Calcula la direcci�n hacia la posici�n del rat�n
        Vector3 direccion = (posicionRaton - transform.position).normalized;

        // Instancia el proyectil
        GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);

        // Aplica fuerza al proyectil en la direcci�n calculada
        Rigidbody2D rbProyectil = proyectil.GetComponent<Rigidbody2D>();
        rbProyectil.velocity = direccion * velocidadProyectil;

        // Destruye el proyectil despu�s de un tiempo
        Destroy(proyectil, 2f);
    }
}