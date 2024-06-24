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
    [SerializeField] private int startCarnivore = 3;
    void Start()
    {
        //CarnivoreReproduction();
        if (pool == null)
        {
            pool = GetComponent<CarnivorePool>();
        }
        if (pool == null)
        {
            pool = FindObjectOfType<CarnivorePool>();
        }
        for (int i = startCarnivore; i >0; i--)
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

    private void CarnivoreReproduction()
    {
        float numberOfCarnivores = GameObject.FindGameObjectsWithTag("Carnivore").Length;
        if (numberOfCarnivores % NumberToReproduce != 0) numberOfCarnivores -= numberOfCarnivores % NumberToReproduce;
        //transformer en loop for
        while(numberOfCarnivores > 0)
        {
            StartCoroutine(Create());
            numberOfCarnivores -= NumberToReproduce;
        }
    }
    public void CarnivoreReproduction(float maxToReproduce)
    {
        int nbRepro=0;;
        while(nbRepro < NumberToReproduce)
        {
            StartCoroutine(Create());
            nbRepro ++;
        }
    }

    public void Dies(int nbCarnivores)
    {
        for(int _=nbCarnivores;_>0;_--){

            pool.Kill(GameObject.FindGameObjectsWithTag("Carnivore")[(int)Mathf.Floor(Random.Range(0,GameObject.FindGameObjectsWithTag("Carnivore").Length-1))].GetComponent<CarnivorePoolMember>());
        }
    }
}
