using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaFase1Script : MonoBehaviour
{
    public GameObject[] fases;
    private int actualUnlock;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("unlock"))
        {
            PlayerPrefs.SetInt("unlock", 0);

        }
        else {
           // PlayerPrefs.SetInt("unlock", actualUnlock);
        }
        actualUnlock = PlayerPrefs.GetInt("unlock");
        int temp = 0;
        foreach (GameObject fase in fases) {
            if (temp <= actualUnlock)
            {
                fase.SetActive(true);
            }
            else {
                fase.SetActive(false);
            }
            temp += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
