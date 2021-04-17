using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMin3Script : MonoBehaviour
{
    public GameObject aroBlack;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("instantiateAro", 2, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void instantiateAro()
    {
        Instantiate(aroBlack, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);

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
