using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    Button button;
    void Start()
    {
        if (this.gameObject.name == "btnJugar")
        {
            if (GetComponent<Button>())
            {
                button = GetComponent<Button>();
                button.Select();
            }


        }


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
