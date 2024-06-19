using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        float numberOfHerbivores = GameObject.FindGameObjectsWithTag("Herbivore").Length;
        if (numberOfHerbivores % NumberToReproduce != 0){ numberOfHerbivores -= numberOfHerbivores % NumberToReproduce;}
        while(numberOfHerbivores > 0)
        {
            StartCoroutine(Create());
            numberOfHerbivores -= NumberToReproduce;
        }
    }

    public void HerbivoreReproduction(float maxToReproduce)
    {
        int nbRepro = 0;

        while(nbRepro < maxToReproduce)
        {
            Create();
            nbRepro++;
        }
    }

    public void Dies(int nbHerbivores)
    {
        for(int _=nbHerbivores;_>0;_--){

            pool.Kill(GameObject.FindGameObjectsWithTag("Herbivore")[Random.Range(0,GameObject.FindGameObjectsWithTag("Herbivore").Length-1)].GetComponent<HerbivorePoolMember>());
        }
    }
}

