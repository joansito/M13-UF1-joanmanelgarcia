using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate1 : MonoBehaviour
{
    public GameObject enemy;
    float randomX;
    float randomY;
    float time;
    private GameObject[] getCount;
    int count;
    public int minEnPantalla;
    public int maxPantalla;
    void Start()
    {
        Invoke("InstantiateEnemy", 5);
        InvokeRepeating("masDificultad", 6, 15);
    }

    // Update is called once per frame
    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("Enemy");
        count = getCount.Length;
        countEnemys();
    }

    void InstantiateEnemy()
    {
        if (count<maxPantalla) {
            int number = Random.RandomRange(1, 2);
            time = Random.Range(3, 6);
            Invoke("InstantiateEnemy", time);
            for (int i = 0; i < number; i++)
            {

                randomX = Random.Range(-8, 8);
                randomY = Random.Range(-4, 4);
                Vector3 posicion = new Vector3(randomX, randomY, 0f);
                Instantiate(enemy, posicion, Quaternion.identity);

            }
        }
    
    }
    private void masDificultad() {
        minEnPantalla += 1;
        maxPantalla += 2;
    }
    private void countEnemys()
    {
        
        if (count < minEnPantalla)
        {
            randomX = Random.Range(-8, 8);
            randomY = Random.Range(-4, 4);
            Vector3 posicion = new Vector3(randomX, randomY, 0f);
            Instantiate(enemy, posicion, Quaternion.identity);
        }
    }
}
