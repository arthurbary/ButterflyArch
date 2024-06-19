using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarnivoreFactory : MonoBehaviour
{
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] GameObject prefab;
    [SerializeField] private CarnivorePool pool;
    [SerializeField] private float NumberToReproduce = 2;
    void Start()
    {
        CarnivoreReproduction();
        if (pool == null)
        {
            pool = GetComponent<CarnivorePool>();
        }
        if (pool == null)
        {
            pool = FindObjectOfType<CarnivorePool>();
        }
    }

    private IEnumerator Create()
    {
        NavMeshManager navMeshManager = new NavMeshManager();
        Vector3 randomOnNavMesh = navMeshManager.FindRandomOnNavMesh();
        if (pool != null)
        {
            pool.Spawn(randomOnNavMesh, Quaternion.identity);
        }
        else
        {
            Instantiate(prefab, randomOnNavMesh, Quaternion.identity);
        }
        yield return new WaitForSeconds(cooldown);
    }

    private void CarnivoreReproduction()
    {
        float numberOfCarnivores = GameObject.FindGameObjectsWithTag("Carnivore").Length;
        if (numberOfCarnivores % NumberToReproduce != 0) numberOfCarnivores -= numberOfCarnivores % NumberToReproduce;
        while(numberOfCarnivores > 0)
        {
            StartCoroutine(Create());
            numberOfCarnivores -= NumberToReproduce;
        }
    }
}
