using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openSide;

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    #region spawn

    private void Spawn()
    {
        if (!spawned)
        {
            GameObject roomToInstantiate = null;
            Quaternion roomRotation = Quaternion.identity;

            // Selecciona la sala correcta en función del lado abierto
            switch (openSide)
            {
                case 1:
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    roomToInstantiate = templates.bottomRooms[rand];
                    break;
                case 2:
                    rand = Random.Range(0, templates.topRooms.Length);
                    roomToInstantiate = templates.topRooms[rand];
                    break;
                case 3:
                    rand = Random.Range(0, templates.leftRooms.Length);
                    roomToInstantiate = templates.leftRooms[rand];
                    break;
                case 4:
                    rand = Random.Range(0, templates.rightRooms.Length);
                    roomToInstantiate = templates.rightRooms[rand];
                    break;
            }

            if (roomToInstantiate != null)
            {
                // Instancia la sala
                Instantiate(roomToInstantiate, transform.position, roomToInstantiate.transform.rotation);
            }

            spawned = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnPoint"))
        {
            RoomSpawner otherSpawner = collision.GetComponent<RoomSpawner>();
            if (!otherSpawner.spawned && !spawned)
            {
                // Instancia la sala cerrada si es necesario
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
            }
            spawned = true;
        }
    }


    #endregion
}
