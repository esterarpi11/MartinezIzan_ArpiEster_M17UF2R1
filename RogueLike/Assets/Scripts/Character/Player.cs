using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] public BarraDeVida barraDeVida;
    public float MaxHealth = 500f;
    public float ActualHealth;
    public static Player instance;
    private Animator animator;
    public AudioSource audioMuerte;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        ActualHealth = MaxHealth;
        barraDeVida.UpdateHealthBar(MaxHealth, ActualHealth); 
        animator = gameObject.GetComponent<Animator>();
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
                muerte();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            ActualHealth -= 50;
            barraDeVida.UpdateHealthBar(MaxHealth, ActualHealth);
            Destroy(other.gameObject);

            if (ActualHealth <= 0)
            {
                muerte();
            }
        }
    }
    void muerte()
    {
        audioMuerte.Play();
        animator.SetBool("dead", true);
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(5);
        animator.SetBool("dead", false);
        gameObject.SetActive(false);
    }
    public void backToLobby()
    {
        gameObject.transform.position = new Vector3(0.6f, 0.03f, -0.04075508f);
        gameObject.SetActive(true);
        ActualHealth = MaxHealth;
        barraDeVida.UpdateHealthBar(MaxHealth, ActualHealth);
    }
}
