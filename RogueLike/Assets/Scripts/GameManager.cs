using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Inventario inventario;
    public int run = 1;
    public int coins = 0;
    public GameObject enterDungeon;
    public GameObject pauseMenu;
    bool menuAbierto = false;
    public GameObject player;
    GameObject spawn;
    //public Text MonedasText;

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
        spawn = GameObject.Find("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool openTienda()
    {
        if (SceneManager.GetActiveScene().name == "Lobby") return true;
        else return false;
    }
    public bool buyWeapon(Arma arma)
    {
        if (!inventario.items.Contains(arma) && arma.price<=coins) return true;
        return false;
    }
    public void setEnemies()
    {
        PlayerPrefs.SetInt("enemiesKilled", PlayerPrefs.GetInt("enemiesKilled") + 1);
    }
    public void getEnemies()
    {
        PlayerPrefs.GetInt("enemiesKilled");
    }
    public void setCoins(int n)
    {
        coins += n;
        //MonedasText.text = Monedas.ToString() + " GC";
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + n);
    }
    public void getCoins()
    {
        PlayerPrefs.GetInt("coins");
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
        else {
            enterDungeon.SetActive(false);
        }
    }
    public bool MenuAbierto()
    {
        if(menuAbierto == true) return true;
        return false;
    }
}
