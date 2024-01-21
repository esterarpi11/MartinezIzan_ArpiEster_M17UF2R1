using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BarraDeVida barraDeVida;
    public float velocidad = 2f;  // Velocidad de persecución del enemigo
    public float statVida = 200;
    public bool isTurret = false;
    protected float vida;
    public GameObject projectilePrefab; // Prefab del proyectil a disparar
    public Transform shootPoint; // Punto de origen del disparo
    public float projectileSpeed = 5f; // Velocidad del proyectil
    private float shootCooldown = 1f; // Tiempo entre disparos
    private float timeSinceLastShot = 0f;
    protected bool alreadyHit = false;

    void Start()
    {
        barraDeVida.UpdateHealthBar(statVida, vida);
        shootPoint = gameObject.transform;
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") && !alreadyHit)
        {
            alreadyHit = true;
            vida -= 25;
            Destroy(other.gameObject);
            barraDeVida.UpdateHealthBar(statVida, vida);

            if (vida <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("Mele"))
        {
            vida -= 25;
            barraDeVida.UpdateHealthBar(statVida, vida);

            if (vida <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    protected void TurretEnemy()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootCooldown)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            // Obtén la posición actual del jugador
            Vector2 playerPosition = PlayerPosition();

            // Calcula la distancia entre el enemigo y el jugador
            float distanceToPlayer = Vector2.Distance(transform.position, playerPosition);

            // Establece un rango máximo para disparar
            float maxShootRange = 10f;  // Ajusta el valor según tu necesidad

            // Verifica si el jugador está dentro del rango antes de disparar
            if (distanceToPlayer <= maxShootRange)
            {
                // El jugador está dentro del rango, procede a disparar
                Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;

                GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

                // Destruir la bala después de 5 segundos
                Destroy(projectile, 5f);
            }
            else
            {
                // El jugador está fuera del rango, no se dispara
                Debug.Log("El jugador está fuera del rango de disparo.");
            }
        }
    }

    Vector2 PlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            return player.transform.position;
        }
        else
        {
            return Vector2.zero;
        }
    }
}
