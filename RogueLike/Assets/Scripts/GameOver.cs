using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text enemigos;
    public Text coins;

    void Start()
    {
        enemigos.text = "ENEMIGOS ASESINADOS: " + PlayerPrefs.GetInt("enemiesKilled");
        coins.text = "MONEDAS CONSEGUIDAS: " + PlayerPrefs.GetInt("coins");  
    }
    public void clickButton(int n)
    {
        GameManager.instance.chooseScene(n);
        if(!(SceneManager.GetActiveScene().name == "EndGame"))
        {
            GameManager.instance.Restart();
        }
    }
}
