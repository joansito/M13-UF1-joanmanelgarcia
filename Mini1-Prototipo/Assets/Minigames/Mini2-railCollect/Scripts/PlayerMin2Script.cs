using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMin2Script : MonoBehaviour
{

    ScorePoints playerPoints;
    bool atacando=false;
    bool bloqueado = false;
    Animator m_Animator;
    bool invencible;
    bool terminado;
    HealthbarScript playerLives;
    TimerPrefab timerObject;
    bool muerto;
    public void Start()
    {
        muerto = false;
        PlayerPrefs.SetInt("PantallaReinicio", 3);
        PlayerPrefs.SetInt("PantallaSalida", 13);
        PlayerPrefs.SetInt("puntosTemp", 0);
        invencible = false;
        playerLives = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthbarScript>();
        m_Animator = gameObject.GetComponent<Animator>();
        playerPoints = GameObject.FindGameObjectWithTag("ScoreBar").GetComponent<ScorePoints>();
        timerObject = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerPrefab>();
    }
    void Update()
    {
        muerto = playerLives.getMuerte();
        if (muerto)
        {

            PlayerPrefs.SetInt("puntosTemp", playerPoints.getPuntos());
            print("muerto");
            SceneManager.LoadScene(9);
        }
        terminado = timerObject.getTerminado();
        if (terminado && !muerto)
        {
            PlayerPrefs.SetInt("puntosTemp", playerPoints.getPuntos());
            print("Terminado");
            int playertemp = PlayerPrefs.GetInt("puntosTemp");
            int puntosF1 = PlayerPrefs.GetInt("puntosF2");
            if (puntosF1 < playertemp)
            {
                PlayerPrefs.SetInt("puntosF2", playertemp);

            }
            SceneManager.LoadScene(10);

        }
        controllerPlayer();
    }
    private void controllerPlayer() {

        if (Input.GetKeyDown("up")&&!bloqueado)
        {
            if (this.transform.position.y < -1.2f)
            {
                this.transform.position += new Vector3(0, 1);
            }

        }
        else if (Input.GetKeyDown("down") && !bloqueado)
        {
            if (this.transform.position.y > -2.99f)
            {
                this.transform.position -= new Vector3(0, 1);
            }
        }
        else if ((Input.GetKeyDown("right") || (Input.GetKeyDown("a"))) && !bloqueado)
        {
           StartCoroutine("ataque");
        
        }
    }
    IEnumerator Invencible()
    {
        m_Animator.SetBool("invencible", true);
        invencible = true;
        yield return new WaitForSeconds(2f);
        m_Animator.SetBool("invencible", false);
        invencible = false;
    }
    IEnumerator ataque() {
        m_Animator.SetBool("ataqueani", true);
        atacando = true;
        bloqueado = true;
        yield return new WaitForSeconds(0.9f);

        m_Animator.SetBool("ataqueani", false);
        bloqueado = false;
        atacando = false;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
       /* if (collision.gameObject.layer == 9 && (Input.GetKey("a") || Input.GetKey("right")))
        {
            //enemigo ataque
            playerPoints.setPuntos(300);
            Destroy(collision.gameObject);
            print("punto");
        }*/
        if (collision.gameObject.layer == 8)
        {
            playerPoints.setPuntos(100);
            Destroy(collision.gameObject);
            print("punto");
        }
       else if (collision.gameObject.layer == 9 && atacando)
        {
            playerPoints.setPuntos(300);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == 14 && !invencible)
        {
            StartCoroutine("Invencible");
            playerLives.setVida(-1);
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 && atacando )
        {
            playerPoints.setPuntos(300);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == 9 && !atacando && !invencible)
        {
            StartCoroutine("Invencible");
            playerLives.setVida(-1);
        }
        else if (collision.gameObject.layer == 8)
        {
            playerPoints.setPuntos(100);
            Destroy(collision.gameObject);
            print("punto");
        } else if (collision.gameObject.layer == 14 && !invencible) {
            playerLives.setVida(-1);
            StartCoroutine("Invencible");
           
        }
      /*  if (collision.gameObject.layer == 8 && (Input.GetKey("a") || Input.GetKey("right")))
        {
            Destroy(collision.gameObject);
            print("punto");
        }*/
    }

}
