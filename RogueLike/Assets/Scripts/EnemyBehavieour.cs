using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavieour : MonoBehaviour
{
    public float velocidad = 5f;  // Velocidad de persecuci�n del enemigo
    private Transform jugador;      // Referencia al transform del jugador

    void Start()
    {
        // Buscar el objeto con el tag "Player" al inicio del juego
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        if (jugador == null)
        {
            Debug.LogError("No se encontr� el objeto con el tag 'Player'.");
        }
    }

    void Update()
    {
        if (jugador != null)
        {
            // Calcular la direcci�n hacia el jugador
            Vector3 direccion = jugador.position - transform.position;

            // Normalizar la direcci�n para que el enemigo se mueva a una velocidad constante
            direccion.Normalize();

            // Mover al enemigo en la direcci�n del jugador
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }
}
