using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HerbivoreFactory : MonoBehaviour
{
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] GameObject prefab;
    [SerializeField] private HerbivorePool pool;
    [SerializeField] private int startHerbivore = 12;
    void Start()
    {
        if (pool == null)
        {
            pool = GetComponent<HerbivorePool>();
        }
        if (pool == null)
        {
            pool = FindObjectOfType<HerbivorePool>();
        }
        for (int i = startHerbivore; i >0; i--)
        {
            StartCoroutine(Create());
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

    

    public void HerbivoreReproduction(float maxToReproduce)
    {
        int nbRepro = 0;

        while(nbRepro < maxToReproduce)
        {
            StartCoroutine(Create());
            nbRepro++;
        }
    }

    public void Dies(int nbHerbivores)
    {
        for(int _=nbHerbivores;_>0;_--){
            float max = GameObject.FindGameObjectsWithTag("Herbivore").Length-1;
            if (max >=0)
            {                
                pool.Kill(GameObject.FindGameObjectsWithTag("Herbivore")[(int) Random.Range(0f, max )].GetComponent<HerbivorePoolMember>());
            };

        }
    }
}

