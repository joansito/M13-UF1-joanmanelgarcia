using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMin4Script : MonoBehaviour
{
    Animator anim;
    private bool pressA;
    int contador;
    ScorePoints score;
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        score = GameObject.FindGameObjectWithTag("ScoreBar").GetComponent<ScorePoints>();
        int contador = 0;
        pressA = false;


}

    // Update is called once per frame
    void Update()
    {
        if (contador == 10)
        {
            spriteRenderer.sprite = spriteArray[0];
        }
        else if (contador == 20)
        {
            spriteRenderer.sprite = spriteArray[1];

        }
        Pulsar();
       
    }

   void Pulsar() {
       
        if (Input.GetKeyUp("a") && !pressA)
        {
            anim.SetBool("pulsado", true);
            pressA = true;
        }
        else if (Input.GetKeyUp("s") && pressA)
        {
            anim.SetBool("pulsado", true);
            contador += 1;
            pressA = false;
            Debug.Log("SSS" + contador);
            score.setPuntos(1);
        }
        else { anim.SetBool("pulsado", false); }



    }
}
