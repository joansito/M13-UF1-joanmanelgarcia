using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiomanagerMap : MonoBehaviour
{
    private AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {

        audioS = GetComponent<AudioSource>();
        audioS.volume = PlayerPrefs.GetFloat("volumen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
