using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePoints : MonoBehaviour
{
    public TextMeshPro contadorText;
    int puntosTotales;
    // Start is called before the first frame update
    void Start()
    {
        puntosTotales = 0;
    }

    // Update is called once per frame
    void Update()
    {

        contadorText.text = puntosTotales.ToString();
    }

    public void setPuntos(int puntos)
    {
        puntosTotales += puntos;
    }
    public int getPuntos() {
        return puntosTotales;
    }
}
