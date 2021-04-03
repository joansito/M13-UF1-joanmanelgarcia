using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshPro contadorText;
    public float segundosFloat;
    float segundosInt;
    bool tiempoTerminado;
    // Start is called before the first frame update
    void Start()
    {
        tiempoTerminado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (segundosFloat > 0)
        {
            segundosFloat -= Time.deltaTime;
            segundosInt = (int)segundosFloat;

            contadorText.text = segundosInt.ToString();

        }
        else
        {
            tiempoTerminado = true;
            segundosFloat = 0;
        }
    }
    
}
