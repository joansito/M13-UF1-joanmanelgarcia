using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthbarScript : MonoBehaviour
{
    public int vidasTotales;
    bool estadoMuerte;
    public TextMeshPro contadorText;

    void Start()
    {  
        estadoMuerte = false;
    }

    void Update()
    {
        if (vidasTotales <= 0) { morir(); }
        contadorText.text = vidasTotales.ToString();
    }

    public void morir()
    {
        estadoMuerte = true;
    }
    public void setVida(int vida)
    {
        vidasTotales+=vida;
    }

    public bool getMuerte() {
        return estadoMuerte;
    }
}
