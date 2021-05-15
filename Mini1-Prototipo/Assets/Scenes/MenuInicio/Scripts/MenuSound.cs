using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    private AudioSource audioS;
    public Slider slider;
    private float volMusic;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("volumen") == false)
        {

            volMusic = 1f;
        }
        else
        {
            slider.value= PlayerPrefs.GetFloat("volumen");
            volMusic = PlayerPrefs.GetFloat("volumen");
        }
        audioS = GetComponent<AudioSource>();
    }
    public void Update() {
        SetVolumeMusic(slider.value);
        audioS.volume = volMusic;
    }
    public void SetVolumeMusic(float volumen)
    {
        
       volMusic= volumen;
        PlayerPrefs.SetFloat("volumen", volumen);
    }
}
