using UnityEngine;

public class Enemy : EnemyBehaviour
{    
    private Transform jugador;// Referencia al transform del jugador

    private void Awake()
    {
        vida = statVida;
    }
    void Start()
    {
        // Buscar el objeto con el tag "Player" al inicio del juego
        jugador = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        alreadyHit = false; // Reiniciar la variable en cada frame
        if (jugador != null && isTurret == false)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direccion = jugador.position - transform.position;

            // Normalizar la dirección para que el enemigo se mueva a una velocidad constante
            direccion.Normalize();

            // Mover al enemigo en la dirección del jugador
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
        if (isTurret)
        {
            TurretEnemy();
        }

    }

    
}
