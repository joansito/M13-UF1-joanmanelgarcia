using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseManagerScript : MonoBehaviour
{
    public TextMeshProUGUI puntosMiniActualText; //prueba
    public TextMeshProUGUI puntosTotalesTempText; //pruebas
    public bool fase1, fase2, fase3, fase4;
    static bool mini1Ganado, mini2Ganado, mini3Ganado;

    static int puntosTotalesTemp;
    int puntosMiniActual;

    void Start()
    {
     
            puntosMiniActual = 0;
        puntosTotalesTempText.text = "Puntos Totales: " +puntosTotalesTemp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            Ganar();
        }
        if (Input.GetKeyDown("s"))
        {
            Perder();
        }
        if (Input.GetKeyDown("right"))
        {
            puntosMiniActual += 10;
            puntosMiniActualText.text = "Puntos Actuales: "+puntosMiniActual.ToString();
        }
    }

    void Ganar()
    {
        if (!mini1Ganado) {
            puntosTotalesTemp += puntosMiniActual;
            mini1Ganado = true;
            SceneManager.LoadScene(7);
        }
        else if (mini1Ganado && !mini2Ganado) {
            puntosTotalesTemp += puntosMiniActual;
            mini2Ganado = true;
            SceneManager.LoadScene(8);
        }
        else if (mini1Ganado && mini2Ganado) {
            
           
            SetPuntosFase();
            SceneManager.LoadScene(1);
        }
        

    }
    void Perder()
    {
        mini2Ganado = false;
        mini1Ganado = false;
        mini3Ganado = false;
        puntosTotalesTemp = 0;
        SceneManager.LoadScene(6);

    }
    void SetPuntosFase()
    {
        puntosTotalesTemp += puntosMiniActual;
        mini1Ganado = false;
        mini2Ganado = false;
        if (fase1)
            {
                if (puntosTotalesTemp > PlayerPrefs.GetInt("puntosFase1"))
                {

                    PlayerPrefs.SetInt("puntosFase1", puntosTotalesTemp); 
                }
            }
            else if (fase2)
            {
                if (puntosTotalesTemp > PlayerPrefs.GetInt("puntosFase2"))
                {

                    PlayerPrefs.SetInt("puntosFase2", puntosTotalesTemp); 
                }
            }
            else if (fase3)
            {
                PlayerPrefs.SetInt("puntosFase3", puntosTotalesTemp); 
            }

        puntosTotalesTemp = 0;

    }
}
