using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavieour : MonoBehaviour
{
    public float velocidad = 5f;  // Velocidad de persecución del enemigo
    private Transform jugador;      // Referencia al transform del jugador

    void Start()
    {
        // Buscar el objeto con el tag "Player" al inicio del juego
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        if (jugador == null)
        {
            Debug.LogError("No se encontró el objeto con el tag 'Player'.");
        }
    }

    void Update()
    {
        if (jugador != null)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direccion = jugador.position - transform.position;

            // Normalizar la dirección para que el enemigo se mueva a una velocidad constante
            direccion.Normalize();

            // Mover al enemigo en la dirección del jugador
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }
}
