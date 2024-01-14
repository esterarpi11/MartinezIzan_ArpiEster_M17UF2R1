using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private BarraDeVida barraDeVida;
    public float velocidad = 2f;  // Velocidad de persecución del enemigo
    private Transform jugador;// Referencia al transform del jugador
    public float statVida = 200;
    private float vida;

    private bool alreadyHit = false; // Variable para evitar múltiples reducciones de vida por una colisión

    void Start()
    {
        vida = statVida;
        barraDeVida.UpdateHealthBar(statVida, vida);
        // Buscar el objeto con el tag "Player" al inicio del juego
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        if (jugador == null)
        {
            Debug.LogError("No se encontró el objeto con el tag 'Player'.");
        }
    }

    void Update()
    {
        alreadyHit = false; // Reiniciar la variable en cada frame
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
        if (other.CompareTag("Bullet") && !alreadyHit)
        {
            alreadyHit = true; // Marcar que ya ha sido impactado para evitar múltiples reducciones de vida

            vida -= 25;
            // Aquí puedes realizar acciones cuando un enemigo colisiona con una bala
            Debug.Log("Enemigo impactado por bala.");
            // Por ejemplo, puedes destruir el enemigo
            Destroy(other.gameObject);
            barraDeVida.UpdateHealthBar(statVida, vida);

            if (vida <= 0)
            {
                // Llamar a la función del jugador para sumar monedas
                if (jugador != null)
                {
                    jugador.GetComponent<Player>().SumarMonedas(Random.Range(5, 8));
                }

                // Destruir el enemigo
                Destroy(gameObject);
            }
        }
    }
}
