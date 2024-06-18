using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPoolMember : MonoBehaviour
{
    // Start is called before the first frame update
    public PlantPool pool;

    private void OnBecameInvisible(){
        pool.Kill(this);
    }
}
