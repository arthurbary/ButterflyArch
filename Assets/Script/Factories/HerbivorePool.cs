using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbivorePool : MonoBehaviour
{
    private Stack<HerbivorePoolMember> pool = new();
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
            GameObject newOne = Instantiate(prefab);
            newOne.GetComponent<HerbivorePoolMember>().pool = this;
            Kill(newOne.GetComponent<HerbivorePoolMember>());
        }
    }

    public HerbivorePoolMember Spawn(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            Create(batch);
        }
        HerbivorePoolMember member = pool.Pop();
        Revive(member,position, rotation);
        return member;
    }

    public void Kill(HerbivorePoolMember member)
    {
        member.gameObject.SetActive(false);
        pool.Push(member);
    }

    public void Revive(HerbivorePoolMember member, Vector3 position, Quaternion rotation)
    {
        member.gameObject.SetActive(true);
        member.transform.position = position;
        member.transform.rotation = rotation;
    }
}
