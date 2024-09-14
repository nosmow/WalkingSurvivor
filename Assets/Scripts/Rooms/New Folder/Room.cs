using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private List<GameObject> grounds;

    [SerializeField] private GameObject topDoor;
    [SerializeField] private GameObject bottomDoor;
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    public Vector2Int RoomIndex { get; set; }


    public void ChangeGround(GameObject room)
    {
        int index = 0;

        if (!room.name.Equals("Room-1"))
        {
            index = Random.Range(1, grounds.Count);
        }

        for (int i = 0; i < grounds.Count; i++)
        {
            if (grounds[i] != grounds[index])
            {
                grounds[i].SetActive(false);
            }
        }
    }

    public void OpenDoor(Vector2Int direction)
    {
        if (direction == Vector2Int.up)
        {
            topDoor.SetActive(false);
        }
        if (direction == Vector2Int.down)
        {
            bottomDoor.SetActive(false);
        }
        if (direction == Vector2Int.left)
        {
            leftDoor.SetActive(false);
        }
        if (direction == Vector2Int.right)
        {
            rightDoor.SetActive(false);
        }
    }
}
