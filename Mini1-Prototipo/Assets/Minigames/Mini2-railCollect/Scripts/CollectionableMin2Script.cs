using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionableMin2Script : MonoBehaviour
{
    public float speedCollect;
  

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position -=new Vector3(speedCollect, 0);
    }

    void OnBecameInvisible()
    {
       Destroy(this.gameObject);
    }
}
