using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroMin3Script : MonoBehaviour
{
    public GameObject refGiro;
    public float vGiro;
    Vector3 axis = new Vector3(0, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 point = refGiro.transform.position;

        transform.RotateAround(point, axis, Time.deltaTime * vGiro);

        this.transform.localScale += new Vector3(0.005f,0.005f,0);
    }
}
