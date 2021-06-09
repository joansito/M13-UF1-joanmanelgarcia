using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMin4Script : MonoBehaviour
{
    Animator anim;
    private bool pressA;
    int contador;
    ScorePoints score;
    public Sprite[] spriteArray;
    public GameObject[] objectMonster;
    public SpriteRenderer spriteRenderer;
    int puntos;
    TimerPrefab timerObject;
    bool terminado;
    public int pulsacionesNecesarias;
    bool ready;
    int monsterIndex;
    // Start is called before the first frame update
    void Start()
    {
        monsterIndex = Random.RandomRange(0, 2);
        ready = false;
        terminado = false;
        PlayerPrefs.SetInt("PantallaReinicio", 5);
        PlayerPrefs.SetInt("PantallaSalida", 17);
        PlayerPrefs.SetInt("puntosTemp", 0);
        timerObject = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerPrefab>();
        puntos = 20;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        score = GameObject.FindGameObjectWithTag("ScoreBar").GetComponent<ScorePoints>();
        contador = 0;
        pressA = false;


}

    // Update is called once per frame
    void Update()
    {
        terminado = timerObject.getTerminado();
        if (terminado && (contador > pulsacionesNecesarias))
        {
            if (PlayerPrefs.GetInt("unlock") == 0)
            {
                PlayerPrefs.SetInt("unlock", 1);
            }
            PlayerPrefs.SetInt("puntosTemp", score.getPuntos());
            print("Terminado");
            int playertemp = PlayerPrefs.GetInt("puntosTemp");
            int puntosF4 = PlayerPrefs.GetInt("puntosF4");
            if (puntosF4 < playertemp)
            {
                PlayerPrefs.SetInt("puntosF4", playertemp);

            }
            SceneManager.LoadScene(10);
        }
        else if(terminado && (contador < pulsacionesNecesarias))
        {
                    SceneManager.LoadScene(9);

                }

     
       
        Pulsar();
       
    }
    void Contar(int contador) {
        int cont = contador;

        switch (contador)
        {
            case 10:
                spriteRenderer.sprite = spriteArray[0];
                break;
            case 20:
                spriteRenderer.sprite = spriteArray[2];
                break;
            case 30:
                spriteRenderer.sprite = spriteArray[3];
                break;
            case 40:
                spriteRenderer.sprite = spriteArray[4];
                break;
            case 50:
                spriteRenderer.sprite = spriteArray[5];
                break;
            case 60:
                spriteRenderer.sprite = spriteArray[6];
                break;
            case 70:
                spriteRenderer.sprite = spriteArray[7];
                break;
            case 80:
                spriteRenderer.sprite = spriteArray[8];
                break;
            case 90:
                ready = true;
                spriteRenderer.sprite = spriteArray[9];
                break;
            default:
                break;

        }
    }
   void Pulsar() {
       
        if (Input.GetKeyUp("right") && !pressA)
        {
            anim.SetBool("pulsado", true);
            pressA = true;
        }
        else if (Input.GetKeyUp("left") && pressA)
        {
            anim.SetBool("pulsado", true);
            contador += 1;
            Contar(contador);
            pressA = false;
            score.setPuntos(puntos);
            if (ready) {
                objectMonster[monsterIndex].SetActive(true);
                objectMonster[monsterIndex].transform.position+=new Vector3(0,0.06f);
            }
        }
        else { anim.SetBool("pulsado", false); }



    }
}
