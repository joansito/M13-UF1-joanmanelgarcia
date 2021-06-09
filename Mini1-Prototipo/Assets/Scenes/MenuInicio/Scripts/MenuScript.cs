using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject opciones;
    public GameObject menu;
    public GameObject slider;
    Button button;
    void Start()
    {
        //hay que cambiar esta parte

       /* if (this.gameObject.name == "btnJugar")
        {
            if (GetComponent<Button>())
            {
                button = GetComponent<Button>();
                button.Select();
            }


        }*/


    }
  
    public void OpenOpciones() {
        menu.SetActive(false);
        opciones.SetActive(true);
        slider.SetActive(true);
    }

    public void SalirOpciones()
    {
        slider.SetActive(false);
        menu.SetActive(true);
        opciones.SetActive(false);
    }

    public void OpenJugar() {
        SceneManager.LoadScene(1);
    }

    public void OpenSalir()
    {
        Application.Quit();
        Debug.Log("Estoy fuera");
    }
}
