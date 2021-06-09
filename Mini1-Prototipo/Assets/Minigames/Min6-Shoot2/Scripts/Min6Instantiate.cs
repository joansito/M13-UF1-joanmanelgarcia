using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Min6Instantiate : MonoBehaviour
{
    public GameObject[] patronsRight;
    public GameObject[] patronsLeft;

    public GameObject SimpleLeft;
    public GameObject SimpleRight;

    public GameObject Enemey;

    int[] posInstanciaX=new int[2];

    void Start()
    {
        posInstanciaX[0] = -10;
        posInstanciaX[1] = 10;
        InvokeRepeating("InstantiatePatron", 30f, 5f);
        InvokeRepeating("InstantiateEnemy", 2f, 5f);
        InvokeRepeating("InstantiateSimple", 2f, 0.7f);

        /*-4 y 4 y*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InstantiatePatron() {

        int numberPatronRight= Random.Range(0, 3);
        Vector3 posicion = new Vector3(-1, 0, 0f);
        Instantiate(patronsRight[numberPatronRight], posicion, Quaternion.identity);

        int numberPatronLeft = Random.Range(0, 3);
        Vector3 posicion2 = new Vector3(13, 0, 0f);
        Instantiate(patronsLeft[numberPatronLeft], posicion2, Quaternion.identity);


    }
    void InstantiateEnemy() {

        float yPos = Random.Range(-4, 4);

        int instaX = Random.Range(0,2);

        Vector3 posicion = new Vector3(posInstanciaX[instaX], yPos, 0f);

        Instantiate(Enemey, posicion, Quaternion.identity);

    }

    void InstantiateSimple() {
        int ins = Random.Range(0, 2);
        float yPos = Random.Range(-4, 4);
        Vector3 posicion;
        if (ins == 0)
        {
            posicion = new Vector3(10, yPos, 0f);
            Instantiate(SimpleLeft, posicion, Quaternion.identity);
        } else if (ins==1) 
        {
            posicion = new Vector3(-10, yPos, 0f);
            Instantiate(SimpleRight, posicion, Quaternion.identity);

        }

    }
}
