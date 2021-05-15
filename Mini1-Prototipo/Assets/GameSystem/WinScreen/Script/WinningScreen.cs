using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WinningScreen : MonoBehaviour
{
    public TMPro.TextMeshProUGUI recordText;
    public TMPro.TextMeshProUGUI actualText;
    int checkPantalla;
    // Start is called before the first frame update
    void Start()
    {
        checkPantalla = PlayerPrefs.GetInt("PantallaReinicio");
        if (checkPantalla == 3) {
            recordText.text = "Record:   " + PlayerPrefs.GetInt("puntosF2").ToString();
            actualText.text = "Puntos totales:   " + PlayerPrefs.GetInt("puntosTemp").ToString();
        } 
        else if (checkPantalla == 2) {
            recordText.text = "Record:   " + PlayerPrefs.GetInt("puntosF1").ToString();
            actualText.text = "Puntos totales:   " + PlayerPrefs.GetInt("puntosTemp").ToString();
        }
      
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenJugar()
    {
        
        SceneManager.LoadScene(PlayerPrefs.GetInt("PantallaSalida"));
    }
}
