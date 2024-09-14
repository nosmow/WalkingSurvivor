using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public List<GameObject> rooms;
    [SerializeField] private GameObject boss;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private int minEnemiesRoom = 3;
    [SerializeField] private int maxEnemiesRoom = 10;

    private void Start()
    {
        Invoke("SpawnEnemies", 2f);
        Invoke("SpawnBoss", 5f);
    }

    private void SpawnBoss()
    {
        var finalBoss = Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
        finalBoss.GetComponent<IAController>().currentRoom = rooms[rooms.Count - 1].transform;
    }

    private void SpawnEnemies()
    {
        for (int i = 1; i < rooms.Count - 1; i++)
        {
            int numberEnemies = Random.Range(minEnemiesRoom, maxEnemiesRoom);

            for (int e = 0; e < numberEnemies; e++)
            {
                int index = Random.Range(0, enemies.Count);
                var enemy = Instantiate(enemies[index], rooms[i].transform.position, Quaternion.identity);
                enemy.GetComponent<IAController>().currentRoom = rooms[i].transform;
            }
        }
    }
}
