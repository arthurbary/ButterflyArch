using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager
{
    [SerializeField] private float RangePlacement = 50;
    public Vector3 FindRandomOnNavMesh()
    {
        Vector3 randomPlacement = new Vector3 (Random.Range(-RangePlacement, RangePlacement), Random.Range(0, RangePlacement), Random.Range(-RangePlacement, RangePlacement));
        NavMeshHit hit;
        while(NavMesh.SamplePosition(randomPlacement, out hit, 10.0f, NavMesh.AllAreas) == false){
            randomPlacement = new Vector3 (Random.Range(-RangePlacement, RangePlacement), Random.Range(0, RangePlacement), Random.Range(-RangePlacement, RangePlacement));
        }
        Vector3 positionOnNavMesh = hit.position;
        return positionOnNavMesh;
    }

    
}
