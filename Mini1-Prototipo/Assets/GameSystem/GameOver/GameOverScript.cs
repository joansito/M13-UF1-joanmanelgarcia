using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverScript : MonoBehaviour
{

    public TextMeshProUGUI contadorText;
    // Start is called before the first frame update
    void Start()
    {
        contadorText.text = "Puntos totales "+PlayerPrefs.GetInt("puntosTemp").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reintentar() {

        SceneManager.LoadScene(PlayerPrefs.GetInt("PantallaReinicio"));
    }
    public void Salir() {
        SceneManager.LoadScene(PlayerPrefs.GetInt("PantallaSalida"));
    }
}
