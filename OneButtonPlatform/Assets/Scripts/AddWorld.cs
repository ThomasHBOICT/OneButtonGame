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
            mapStorer.AddTilemap(newSpawnPos);
            hasSpawned = true;
        }
    }
}
