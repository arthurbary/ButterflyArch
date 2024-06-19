using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorePool : MonoBehaviour
{
    private Stack<CarnivorePoolMember> pool = new();
    [Range(1, 100)][SerializeField] private int initialBatch = 50;
    [Range(1, 100)][SerializeField] private int batch = 10;

    [SerializeField] GameObject prefab;


    public void Awake()
    {
        Create(initialBatch);
    }

    private void Create(int number)
    {
        for (int _ = 0; _ < number; _++)
        {
            GameObject newOne = Instantiate(prefab, transform.position, Quaternion.identity);
            newOne.GetComponent<CarnivorePoolMember>().pool = this;
            Kill(newOne.GetComponent<CarnivorePoolMember>());
        }
    }

    public CarnivorePoolMember Spawn(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            Create(batch);
        }
        CarnivorePoolMember member = pool.Pop();
        Revive(member,position, rotation);
        return member;
    }

    public void Kill(CarnivorePoolMember member)
    {
        member.gameObject.SetActive(false);
        pool.Push(member);
    }

    public void Revive(CarnivorePoolMember member, Vector3 position, Quaternion rotation)
    {
        member.transform.position = position;
        member.transform.rotation = rotation;
        member.gameObject.SetActive(true);
    }
}
