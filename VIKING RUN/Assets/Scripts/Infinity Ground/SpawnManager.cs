using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawner roadspawner;
    
    // Start is called before the first frame update
    void Start()
    {
        roadspawner = GetComponent<RoadSpawner>();
    }

    public void SpawnTriggerEnter()
    {
        roadspawner.MoveRoad();
    }
}
