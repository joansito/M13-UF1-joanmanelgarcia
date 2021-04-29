using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject canvas;
    bool pause;
    // Start is called before the first frame update
    void Start()
    {

        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (!pause)
        {
            canvas.SetActive(true);
            pause = true;
            Time.timeScale = 0;
        }
        else
        {

            canvas.SetActive(false);
            pause = false;
            Time.timeScale = 1;
        }
    }
}
