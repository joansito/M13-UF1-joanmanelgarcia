using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPantallasLogin : MonoBehaviour
{
   public GameObject login;
   public GameObject registro;
    FireBase Script;
    // Start is called before the first frame update
    void Start()
    {
        Script = GameObject.Find("FireBase").GetComponent<FireBase>(); ;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setLogin() {
        bool estate = Script.GetValid();
        if (estate) {
            login.SetActive(true);
            registro.SetActive(false);
        }
      
    }
    public void setRegistro() {
        bool estate = Script.GetValid();
        if (estate)
        {
            login.SetActive(false);
            registro.SetActive(true);
        }
    }
    public void volverLogin() {
        login.SetActive(true);
        registro.SetActive(false);
    }
    public void volverRegistro()
    {
        login.SetActive(false);
        registro.SetActive(true);
    }
    public void OpenSalir()
    {
        Application.Quit();
    }
}
