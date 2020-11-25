using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maps : MonoBehaviour
{
    public List<Transform> gridStartPoint;
    public Transform shopPart;
    public Transform startPart;
    public Transform gameStartPoint;

    public bool loadStart = false;

    private int numOfMaps = 4;

    private void Start()
    {
        if (loadStart)
        {
        LoadStartMap(gameStartPoint.position);
        }
    }

    public void AddTilemap(Vector3 spawnposition)
    {
        if (numOfMaps == 5)
        {
            Debug.Log("load shop...");
            Instantiate(shopPart, spawnposition, Quaternion.identity);
            numOfMaps = 0;
        }
        else
        {
            int index = Random.Range(0, gridStartPoint.Count);
            Instantiate(gridStartPoint[index], spawnposition, Quaternion.identity);
            numOfMaps++;
        }
        
    }

    private void LoadStartMap(Vector3 spawnposition)
    {
        Instantiate(startPart, spawnposition, Quaternion.identity);
    }
}
