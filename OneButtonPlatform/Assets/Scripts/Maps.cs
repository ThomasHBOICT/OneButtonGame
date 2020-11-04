using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maps : MonoBehaviour
{
    public List<Transform> gridStartPoint;
    public Transform gameStartPoint;

    public bool loadStart = false;

    private void Start()
    {
        if (loadStart)
        {
        AddTilemap(gameStartPoint.position);

        }
    }

    void AddTilemap(Vector3 spawnposition)
    {
        int index = Random.Range(0, gridStartPoint.Count);
        Instantiate(gridStartPoint[index], spawnposition, Quaternion.identity);
    }
}
