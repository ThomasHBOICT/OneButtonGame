using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWorld : MonoBehaviour
{
    public Transform gridEndPoint;
   
    private bool hasSpawned = false;
    private Maps mapStorer;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !hasSpawned)
        {
            mapStorer = GameObject.Find("MapStorer").GetComponent<Maps>();
            Vector3 newSpawnPos = gridEndPoint.position;
            AddTilemap(newSpawnPos);
            hasSpawned = true;
        }
    }

    void AddTilemap(Vector3 spawnposition)
    {
        int index = Random.Range(0, mapStorer.gridStartPoint.Count);
        Instantiate(mapStorer.gridStartPoint[index], spawnposition, Quaternion.identity);
    }
}
