using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbivorePoolMember : MonoBehaviour
{
    public HerbivorePool pool;

    private void OnBecameInvisible(){
        pool.Kill(this);
    }
}
