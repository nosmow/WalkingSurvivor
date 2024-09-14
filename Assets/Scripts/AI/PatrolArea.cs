using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolArea : MonoBehaviour
{
    //Patrol area size
    [SerializeField] private Vector2 patrolSize = new Vector2(8, 10);

    //Returns a random point for patrolling
    public Vector2 GetRandomPoint()
    {
        if (!gameObject.name.Equals("Room-1"))
        {
            float randomX = Random.Range(-patrolSize.x / 2, patrolSize.x / 2);
            float randomY = Random.Range(-patrolSize.y / 2, patrolSize.y / 2);
            return (Vector2)transform.position + new Vector2(randomX, randomY);
        }
        else
        {
            return Vector2.zero;
        }
    }

    //Displaying the area in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(patrolSize.x, patrolSize.y, 0));
    }
}
