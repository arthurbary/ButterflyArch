using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbivoreFactory : MonoBehaviour
{
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] GameObject prefab;
    [SerializeField] private HerbivorePool pool;
    [SerializeField] private float NumberToReproduce = 2;
    void Start()
    {
        HerbivoreReproduction();
        if (pool == null)
        {
            pool = GetComponent<HerbivorePool>();
        }
        if (pool == null)
        {
            pool = FindObjectOfType<HerbivorePool>();
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

    private void HerbivoreReproduction()
    {
        float numberOfPlants = GameObject.FindGameObjectsWithTag("Herbivore").Length;
        if (numberOfPlants % NumberToReproduce != 0){ numberOfPlants -= numberOfPlants % NumberToReproduce;}
        while(numberOfPlants > -30)
        {
            StartCoroutine(Create());
            numberOfPlants -= NumberToReproduce;
        }
    }
}
