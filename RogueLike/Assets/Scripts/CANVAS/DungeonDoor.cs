using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoor : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.EnterDungeon();
    }
    public void ChooseOption(int n)
    {
        gameManager.ChooseEnter(n);
    }
}
