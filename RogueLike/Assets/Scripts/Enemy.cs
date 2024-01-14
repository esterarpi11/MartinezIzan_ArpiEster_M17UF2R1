using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BarraDeVida barraDeVida;
    public float velocidad = 2f;  // Velocidad de persecución del enemigo
    public float statVida = 200;
    public float vida;
    //GameManager gameManager;
    protected bool alreadyHit = false; // Variable para evitar múltiples reducciones de vida por una colisión

    void Start()
    {
        //gameManager = GameManager.instance;
        barraDeVida.UpdateHealthBar(statVida, vida);
    }

    // Update is called once per frame
    void Update()
    {        Debug.Log(vida + " update");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si la colisión es con un objeto que tenga el tag "Bullet"
        if (other.CompareTag("Bullet") && !alreadyHit)
        {
            alreadyHit = true; // Marcar que ya ha sido impactado para evitar múltiples reducciones de vida
            Debug.Log(vida + " before -");
            vida -= 25;
            Debug.Log(vida + " after -");
            // Aquí puedes realizar acciones cuando un enemigo colisiona con una bala
            Debug.Log("Enemigo impactado por bala.");
            // Por ejemplo, puedes destruir el enemigo
            Destroy(other.gameObject);
            barraDeVida.UpdateHealthBar(statVida, vida);

            if (vida <= 0)
            {
                // Llamar a la función del jugador para sumar monedas
                
                //gameManager.setCoins(Random.Range(5, 8));
                

                // Destruir el enemigo
                Destroy(gameObject);
            }
        }
    }
}
