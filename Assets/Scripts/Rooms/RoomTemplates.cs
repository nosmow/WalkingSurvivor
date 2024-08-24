using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public GameObject boos;
    public GameObject enemy;

    private void Start()
    {
        Invoke("SpawnEnemies", 3f);
    }

    private void SpawnEnemies()
    {
        Instantiate(boos, rooms[rooms.Count - 1].transform.position, Quaternion.identity);

        for (int i = 0; i < rooms.Count - 1; i++)
        {
            Instantiate(enemy, rooms[i].transform.position, Quaternion.identity);
        }
    }
}
