using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantFactory : MonoBehaviour
{
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] GameObject prefab;
    [SerializeField] private PlantPool pool;
    [SerializeField] private float RangePlacement;
    [SerializeField] private float NumberToReproduce = 2;
    void Start()
    {
        PlantReproduction();
        if (pool == null)
        {
            pool = GetComponent<PlantPool>();
        }
        if (pool == null)
        {
            pool = FindObjectOfType<PlantPool>();
        }
        //StartCoroutine(Create());
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

    private void PlantReproduction()
    {
        float numberOfPlants = GameObject.FindGameObjectsWithTag("Plant").Length;
        if (numberOfPlants % NumberToReproduce != 0) numberOfPlants -= numberOfPlants % NumberToReproduce;
        while(numberOfPlants > -20)
        {
            StartCoroutine(Create());
            numberOfPlants -= NumberToReproduce;
        }
    }
    public void PlantReproduction(float maxToReproduce)
    {
        float numberOfPlants = GameObject.FindGameObjectsWithTag("Plant").Length;
        while(numberOfPlants < maxToReproduce)
        {
            Create();
            numberOfPlants++ ;
        }
    }

    public void Dies(int nbPlants)
    {
        for(int _=nbPlants;_>0;_--){

            pool.Kill(GameObject.FindGameObjectsWithTag("Plant")[Random.Range(0,GameObject.FindGameObjectsWithTag("Plant").Length-1)].GetComponent<PlantPoolMember>());
        }
    }

}