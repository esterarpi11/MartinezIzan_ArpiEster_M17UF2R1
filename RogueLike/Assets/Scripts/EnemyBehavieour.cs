using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject BarraVida;
    public float velocidad = 2f;  // Velocidad de persecución del enemigo
    private Transform jugador;// Referencia al transform del jugador
    public float statVida = 200f;
    private float vida;

    void Start()
    {
        vida = statVida;
        BarraDeVida.UpdateHealthBar(statVida,vida);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si la colisión es con un objeto que tenga el tag "Bullet"
        if (other.CompareTag("Bullet"))
        {
            vida -= 25;
            // Aquí puedes realizar acciones cuando un enemigo colisiona con una bala
            Debug.Log("Enemigo impactado por bala.");
            // Por ejemplo, puedes destruir el enemigo
            Destroy(other.gameObject);
            BarraDeVida.UpdateHealthBar(statVida,vida);

            if (vida <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
