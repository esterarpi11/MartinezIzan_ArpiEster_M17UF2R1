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
        if(n != -1)
        {
            if(n == 1) GameManager.instance.Restart();
            GameManager.instance.chooseScene(1);
            GameManager.instance.tpPLayerLobby();
            GameManager.instance.run = 1;
        }
        GameManager.instance.chooseScene(n);
    }
}
