using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapaTextoPuntosFase : MonoBehaviour
{
    public TextMeshProUGUI contadorText;
    int puntosDeFase;
    // Start is called before the first frame update
    void Start()
    {
        puntosDeFase = PlayerPrefs.GetInt("puntosFase1");
        contadorText.text = puntosDeFase.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
