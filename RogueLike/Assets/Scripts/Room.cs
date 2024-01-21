using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] GameObject topDoor;
    [SerializeField] GameObject bottomDoor;
    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor; 

    [SerializeField] GameObject topWall;
    [SerializeField] GameObject bottomWall;
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;

    [SerializeField] GameObject decoracion1;
    [SerializeField] GameObject decoracion2;
    [SerializeField] GameObject decoracion3;

    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    [SerializeField] GameObject enemy4;
    [SerializeField] GameObject enemy5;
    [SerializeField] GameObject enemy6;

    GameManager gameManager;

    public Vector2Int RoomIndex { get; set; }

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void OpenDoor(Vector2Int direction)
    {
        if(direction == Vector2Int.up)
        {
            topDoor.SetActive(true);
            topWall.SetActive(false);
        }
        if (direction == Vector2Int.down)
        {
            bottomDoor.SetActive(true);
            bottomWall.SetActive(false);
        }
        if (direction == Vector2Int.left)
        {
            leftDoor.SetActive(true);
            leftWall.SetActive(false);
        }
        if (direction == Vector2Int.right)
        {
            rightDoor.SetActive(true);
            rightWall.SetActive(false);
        }
    }
    public void ChosenFloor(int floor)
    {
        switch(floor)
        {
            case 1:
                decoracion1.SetActive(true);
                break;
            case 2:
                decoracion2.SetActive(true);
                break;
            case 3: 
                decoracion3.SetActive(true); 
                break;
        }
    }
    public void SetEnemies()
    {
        int run = 2;

        switch (run)
        {
            case 1:              
                setActive(getRandom(random(1, 3)));
                break;
            case 2:

                setActive(getRandom(random(3, 5)));
                break;
            default:
                setActive(getRandom(random(5, 7)));
                break;
        }
    }
    void setActive(int[] randoms)
    {
        GameObject[] enemies = { enemy1, enemy2, enemy3, enemy4, enemy5, enemy6 };
        foreach(int i in randoms)
        {
            enemies[i-1].SetActive(true);
        }
    }
    int[] getRandom(int tamano)
    {
        List<int> numerosDisponibles = new List<int>();
        for (int i = 1; i <= 6; i++)
        {
            numerosDisponibles.Add(i);
        }

        int[] numerosRandom = new int[tamano];
        for (int i = 0; i < tamano; i++)
        {
            int indiceRandom = Random.Range(0, numerosDisponibles.Count);
            numerosRandom[i] = numerosDisponibles[indiceRandom];
            numerosDisponibles.RemoveAt(indiceRandom);
        }
        return numerosRandom;
    }
    int random(int a, int b)
    {
        int random = Random.Range(a, b);
        gameManager.numeroEnemigos += random;
        return random;
    }
}
