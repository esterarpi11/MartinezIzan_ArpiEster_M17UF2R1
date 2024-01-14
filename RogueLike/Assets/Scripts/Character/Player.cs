using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField] private BarraDeVida barraDeVida;
    public float MaxHealth = 500f;
    private float ActualHealth;
    public Text MonedasText;
    public int Monedas { get; private set; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        ActualHealth = MaxHealth;
        barraDeVida.UpdateHealthBar(MaxHealth, ActualHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Verificar si la colisión es con un objeto que tenga el tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ActualHealth -= 100 * Time.deltaTime; // Reducir la salud con el tiempo
            // Aquí puedes realizar acciones mientras el jugador está tocando al enemigo
            // Por ejemplo, puedes actualizar la barra de vida
            barraDeVida.UpdateHealthBar(MaxHealth, ActualHealth);

            if (ActualHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void SumarMonedas(int cantidad)
    {
        Monedas += cantidad;
        Debug.Log("Monedas actuales: " + Monedas);
        MonedasText.text =Monedas.ToString()+" GC";
        // Aquí puedes realizar acciones adicionales cuando se suman monedas
    }
}
