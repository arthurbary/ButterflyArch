using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPool : MonoBehaviour
{
    private Stack<PlantPoolMember> pool = new();
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
            newOne.GetComponent<PlantPoolMember>().pool = this;
            Kill(newOne.GetComponent<PlantPoolMember>());
        }
    }

    public PlantPoolMember Spawn(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            Create(batch);
        }
        PlantPoolMember member = pool.Pop();
        Revive(member,position, rotation);
        return member;
    }

    public void Kill(PlantPoolMember member)
    {
        member.gameObject.SetActive(false);
        pool.Push(member);
    }

    public void Revive(PlantPoolMember member, Vector3 position, Quaternion rotation)
    {
        member.gameObject.SetActive(true);
        member.transform.position = position;
        member.transform.rotation = rotation;
    }
}
