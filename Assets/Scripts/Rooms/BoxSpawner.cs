using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> boxes;
    private PatrolArea patrolArea;
    [SerializeField] private int minBoxes = 2;
    [SerializeField] private int maxBoxes = 5;
    [SerializeField] private float boxSize = 1f;

    private List<Vector2> spawnedPosition = new List<Vector2>();

    private void Start()
    {
        patrolArea = GetComponent<PatrolArea>();
        Invoke("SpawnBoxes", 2f);
    }

    private void SpawnBoxes()
    {
        int spawnedCount = 0;
        int maxAttempts = 100;

        int numberBoxes = Random.Range(minBoxes, maxBoxes);

        while (spawnedCount < numberBoxes && maxAttempts > 0)
        {
            Vector2 spawnPosition = patrolArea.GetRandomPoint();
            
            if (spawnPosition != Vector2.zero && !IsPositionOccupied(spawnPosition))
            {
                int index = Random.Range(0, boxes.Count);
                Instantiate(boxes[index], spawnPosition, Quaternion.identity);
                spawnedPosition.Add(spawnPosition);
                spawnedCount++;
            }
            maxAttempts--;
        }
    }
    
    private bool IsPositionOccupied(Vector2 position)
    {
        foreach ( var occupiedPosition in spawnedPosition)
        {
            if (Vector2.Distance(occupiedPosition, position) < boxSize)
            {
                return true;
            }
        }

        return false;
    }
}
