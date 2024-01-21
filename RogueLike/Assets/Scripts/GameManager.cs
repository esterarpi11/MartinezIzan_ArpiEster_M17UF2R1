using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Inventario inventario;
    public int run = 1;
    private int coins = 0;
    public GameObject enterDungeon;
    public GameObject pauseMenu;
    bool menuAbierto = false;
    public GameObject player;
    GameObject spawn;
    public int numeroEnemigos;
    public Text MonedasText;
    public AudioSource endMazmorra;

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
        inventario = Inventario.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            spawn = GameObject.Find("Spawn");
            player = GameObject.Find("Player");
            spawn.transform.position = player.transform.position;

            if (numeroEnemigos == 0)
            {
                endMazmorra.Play();
                StartCoroutine(wait());
            }
        }
        if(MonedasText != null) MonedasText.text = coins.ToString() + " oro";
    }
    public bool openTienda()
    {
        if (SceneManager.GetActiveScene().name == "Lobby") return true;
        else return false;
    }
    public bool buyWeapon(Arma arma)
    {
        if (!inventario.items.Contains(arma) && arma.price <= coins)
        {
            Debug.Log(!inventario.items.Contains(arma));
            Debug.Log(arma.price + " " + coins);
            coins -= arma.price;
            return true;
        }
        Debug.Log(!inventario.items.Contains(arma));
        Debug.Log(arma.price + " " + coins);
        return false;
    }
    public void setEnemies()
    {
        PlayerPrefs.SetInt("enemiesKilled", PlayerPrefs.GetInt("enemiesKilled") + 1);
    }
    public void setCoins(int n)
    {
        coins += n;
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + n);
    }
    public void EnterDungeon()
    {
        enterDungeon.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ChooseEnter(int n)
    {
        Time.timeScale = 1f;
        if (n >= 1)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            enterDungeon.SetActive(false);
        }
    }
    public bool MenuAbierto()
    {
        if (menuAbierto == true) return true;
        return false;
    }
    public void chooseScene(int n)
    {
        if (n >= 0)
        {
            SceneManager.LoadScene(n);
        }
        else
        {
            Application.Quit();
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetInt("enemiesKilled", 0);
    }

}
