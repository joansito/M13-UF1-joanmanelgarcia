using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMin3Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Destroy(collision.gameObject);
            Debug.Log("Eliminado");
        }
        Debug.Log("Algo detectado");

    }
    
}
