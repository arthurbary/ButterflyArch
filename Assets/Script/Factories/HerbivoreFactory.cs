using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbivoreFactory : MonoBehaviour
{
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] GameObject prefab;
    [SerializeField] private HerbivorePool pool;
    [SerializeField] private float RangePlacement;
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

    private void HerbivoreReproduction()
    {
        float numberOfPlants = GameObject.FindGameObjectsWithTag("Herbivore").Length;
        if (numberOfPlants % NumberToReproduce != 0){ numberOfPlants -= numberOfPlants % NumberToReproduce;}
        while(numberOfPlants > 0)
        {
            StartCoroutine(Create());
            numberOfPlants -= NumberToReproduce;
        }
    }
}
