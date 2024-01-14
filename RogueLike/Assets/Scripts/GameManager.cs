using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setPrefs(string pref)
    {
        PlayerPrefs.SetInt(pref, PlayerPrefs.GetInt(pref)+1);
        PlayerPrefs.Save();
    }
    void getPrefs(string pref)
    {
        PlayerPrefs.GetInt(pref);
    }
}
