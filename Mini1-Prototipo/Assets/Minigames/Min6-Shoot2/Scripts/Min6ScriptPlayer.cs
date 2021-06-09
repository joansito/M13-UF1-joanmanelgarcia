using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Min6ScriptPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    bool pulsado;
    bool shoot;
    public Rigidbody2D a;
    public GameObject bulletRight;
    public GameObject bulletLeft;
    public float delanteSpeed = 0.06f;
    HealthbarScript playerLives;
    TimerPrefab timerObject;
    ScorePoints playerPoints;
    bool muerto;
    Animator m_Animator;
    bool invencible;

    bool terminado;
    void Start()
    {
        invencible = false;
        muerto = false;
        PlayerPrefs.SetInt("PantallaReinicio", 16);
        PlayerPrefs.SetInt("PantallaSalida", 12); //cambiar pantalla
        PlayerPrefs.SetInt("puntosTemp", 0);
        pulsado = false;
        shoot = false;
        playerLives = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthbarScript>();
        timerObject = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerPrefab>();
        playerPoints = GameObject.FindGameObjectWithTag("ScoreBar").GetComponent<ScorePoints>();
    }

    // Update is called once per frame
    void Update()
    {
        terminado = timerObject.getTerminado();
        if (terminado && !muerto)
        {
            PlayerPrefs.SetInt("puntosTemp", playerPoints.getPuntos());
            print("Terminado");
            int playertemp = PlayerPrefs.GetInt("puntosTemp");
            int puntosF1 = PlayerPrefs.GetInt("puntosF1");
            if (puntosF1 < playertemp)
            {
                PlayerPrefs.SetInt("puntosF1", playertemp);

            }
            SceneManager.LoadScene(10);

        }
    }
   void FixedUpdate()
    {
        muerto = playerLives.getMuerte();
        if (muerto)
        {
            PlayerPrefs.SetInt("puntosTemp", playerPoints.getPuntos());
            SceneManager.LoadScene(9);
        }
        moveKeys();
    }

    IEnumerator Invencible()
    {
        //m_Animator.SetBool("invencible", true);
        invencible = true;
        yield return new WaitForSeconds(2f);
        //m_Animator.SetBool("invencible", false);
        invencible = false;
    }

    void moveKeys()
    {
        if (Input.GetKey("up") && !pulsado)
        {
            pulsado = true;
            a.AddForce(transform.up.normalized * delanteSpeed);
            a.velocity = a.velocity.normalized * delanteSpeed;
        }
        else if (Input.GetKey("down") && !pulsado)
        {
            pulsado = true;
            a.AddForce(-transform.up.normalized * delanteSpeed);
            a.velocity = a.velocity.normalized * delanteSpeed;
        }
        else if (Input.GetKey("right") && !shoot)
        {
            Vector3 actual = new Vector3(transform.position.x+0.3f, transform.position.y, 0);
            Instantiate(bulletRight, actual, Quaternion.identity);
            StartCoroutine("shootState");
        }
        else if (Input.GetKey("left") && !shoot)
        {
            Vector3 actual = new Vector3(transform.position.x-0.3f, transform.position.y, 0);
            Instantiate(bulletLeft, actual, Quaternion.identity);
            StartCoroutine("shootState");
        }
        else
        {
            a.velocity *= 0;
            pulsado = false;
        }
    }

    IEnumerator shootState()
    {
        shoot = true;
        yield return new WaitForSeconds(0.3f);
        shoot = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            playerLives.setVida(-1);
            Destroy(collision.gameObject);

            StartCoroutine("Invencible");
        }
    }
 
}
