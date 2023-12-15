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
    [SerializeField] GameObject decoracion4;

    public Vector2Int RoomIndex { get; set; }

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
}
