using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectionableBar : MonoBehaviour
{
    public int coleccionablesTotales;
    int coleccionablesRecogidos;
    public TextMeshPro contadorText;
    // Start is called before the first frame update
    void Start()
    {
        coleccionablesRecogidos =0;
    }

    // Update is called once per frame
    void Update()
    {

        contadorText.text = coleccionablesRecogidos.ToString() + ("/") + coleccionablesTotales.ToString(); ;
    }

    public void setColeccionable(int puntos) {

        coleccionablesRecogidos += 1;
    }
}
