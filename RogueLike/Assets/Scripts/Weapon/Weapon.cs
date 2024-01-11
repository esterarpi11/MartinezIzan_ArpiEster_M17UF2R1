using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public float velocidadProyectil = 10f;
    public int numProyectiles = 1;
    public float velocidadRotacionArma = 5f;

    // Variables para ajustar la posición relativa del arma
    public float offsetX = 1f;
    public float offsetY = 0f;

    void Update()
    {
        // Obtener la posición del ratón en el mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Calcular la dirección hacia el ratón desde el arma
        Vector3 direccion = mousePos - transform.position;

        // Calcular el ángulo en radianes y convertirlo a grados
        float angle = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Rotar el arma hacia el ratón
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), velocidadRotacionArma * Time.deltaTime);

        // Ajustar la posición del arma relativa al jugador
        transform.position = new Vector3(transform.parent.position.x + offsetX, transform.parent.position.y + offsetY, transform.position.z);

        // Detectar clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            DispararProyectil();
        }
    }

    void DispararProyectil()
    {
        for (int i = 0; i < numProyectiles; i++)
        {
            // Instancia el proyectil
            GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);

            // Aplica fuerza al proyectil en la dirección calculada con dispersión
            Rigidbody2D rbProyectil = proyectil.GetComponent<Rigidbody2D>();
            Vector3 direccion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            if (numProyectiles > 1)
            {
                // Calcula un ángulo de dispersión aleatorio en el rango de 120 grados
                float dispersionAngle = Random.Range(-60f, 60f);

                // Rota la dirección original según el ángulo de dispersión
                Quaternion dispersionRotation = Quaternion.AngleAxis(dispersionAngle, Vector3.forward);
                Vector3 dispersedDirection = dispersionRotation * direccion.normalized;

                // Aplica fuerza al proyectil en la dirección dispersa
                rbProyectil.velocity = dispersedDirection * velocidadProyectil;
            }
            else
            {
                // Si solo hay un proyectil, aplica la fuerza en la dirección original
                rbProyectil.velocity = direccion.normalized * velocidadProyectil;
            }

            // Destruye el proyectil después de un tiempo
            Destroy(proyectil, 2f);
        }
    }
}
