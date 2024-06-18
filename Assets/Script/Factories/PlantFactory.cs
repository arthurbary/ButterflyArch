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
            Vector3 randomPlacement = new Vector3 (Random.Range(-RangePlacement, RangePlacement), 0, Random.Range(-RangePlacement, RangePlacement));
            if (pool != null)
            {
                pool.Spawn(randomPlacement, Quaternion.identity);
            }
            else
            {
                Instantiate(prefab, randomPlacement, Quaternion.identity);
            }
            yield return new WaitForSeconds(cooldown);
    }

    private void PlantReproduction()
    {
        float numberOfPlants = GameObject.FindGameObjectsWithTag("Plant").Length;
        if (numberOfPlants % NumberToReproduce != 0) numberOfPlants -= numberOfPlants % NumberToReproduce;
        while(numberOfPlants > 0)
        {
            StartCoroutine(Create());
            numberOfPlants -= NumberToReproduce;
        }
    }

}