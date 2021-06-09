using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMini5 : MonoBehaviour
{
    public GameObject enemy;
    public GameObject obstacle;
    float randomX;
    float randomY;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("InstantiateEnemy", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateEnemy()
    {
            int number = Random.Range(1, 2);
        print(number);
            time = Random.Range(2, 5);
            Invoke("InstantiateEnemy", time);

                randomX = Random.Range(-6, 6);
                randomY = Random.Range(8, 5.5f);
            Vector3 posicion = new Vector3(randomX, 8, 0f);
                Instantiate(enemy, posicion, Quaternion.identity);
        

    }
}
