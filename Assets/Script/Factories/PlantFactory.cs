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
    NavMeshManager navMeshManager;
    void Start()
    {
        navMeshManager = new NavMeshManager();
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

    public void PlantReproduction(float maxToReproduce)
    {

        for(int nbRepro=0; nbRepro <maxToReproduce; nbRepro++)
        {
            StartCoroutine(Create());
        }
    }

    public void Dies(int nbPlants)
    {
        for(int _=nbPlants;_>0;_--){
            pool.Kill(GameObject.FindGameObjectsWithTag("Plant")[(int)Mathf.Floor(Random.Range(0,GameObject.FindGameObjectsWithTag("Plant").Length-1))].GetComponent<PlantPoolMember>());
        }
    }

}
