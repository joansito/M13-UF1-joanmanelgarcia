using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaFase1Script : MonoBehaviour
{
   public bool completado;
    // Start is called before the first frame update
    void Start()
    {
        if (!completado) {

            PlayerPrefs.SetInt("puntosMaximosFase1", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCompletado() {
        Debug.Log("HAS ACTIVADO LA FASE 1");
        //completado = true;
    }


    //ESTO NO HACE FALTA
    public void setPuntos(int puntosSetter) {

        PlayerPrefs.SetInt("puntosMaximosFase1", puntosSetter);
    }

    public int getPuntos() {
        int puntosGetter = PlayerPrefs.GetInt("puntosMaximosFase1");
        return puntosGetter;
    }
}
