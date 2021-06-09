using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMini5 : MonoBehaviour
{
    public Rigidbody2D a;
    public float delanteSpeed = 0.06f;
    public GameObject bullet;
    bool pulsado;
    bool shoot;
    bool terminado;
    bool muerto;
    TimerPrefab timerObject;
    HealthbarScript playerLives;

    ScorePoints playerPoints;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PantallaReinicio", 15);
        PlayerPrefs.SetInt("PantallaSalida", 11);
        PlayerPrefs.SetInt("puntosTemp", 0);
        pulsado = false;
        shoot = false;
        playerPoints = GameObject.FindGameObjectWithTag("ScoreBar").GetComponent<ScorePoints>();
        timerObject = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerPrefab>();
        playerLives = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthbarScript>();
    }
    public void Update()
    {
        terminado = timerObject.getTerminado();
        if (terminado && !muerto)
        {
            if (PlayerPrefs.GetInt("unlock") == 2)
            {
                PlayerPrefs.SetInt("unlock", 3);
            }
            PlayerPrefs.SetInt("puntosTemp", playerPoints.getPuntos());
            print("Terminado");
            int playertemp = PlayerPrefs.GetInt("puntosTemp");
            int puntosF3 = PlayerPrefs.GetInt("puntosF3");
            if (puntosF3 < playertemp)
            {
                PlayerPrefs.SetInt("puntosF3", playertemp);

            }
            SceneManager.LoadScene(10);

        }
        muerto = playerLives.getMuerte();
        if (muerto)
        {

            PlayerPrefs.SetInt("puntosTemp", playerPoints.getPuntos());
            print("muerto");
            SceneManager.LoadScene(9);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        moveKeys();   
    }
 
    void moveKeys()
    { 
       if (Input.GetKey("right") && !pulsado)
        {
            pulsado = true;
            a.AddForce(transform.right.normalized* delanteSpeed);
            a.velocity = a.velocity.normalized* delanteSpeed;
        }
        else if (Input.GetKey("left") && !pulsado)
        {
            pulsado = true;
            a.AddForce(-transform.right.normalized * delanteSpeed);
            a.velocity = a.velocity.normalized * delanteSpeed;
        }
        else if (Input.GetKey("up")&&!shoot)
        {
            Vector3 actual = new Vector3(transform.position.x, transform.position.y + 0.4f, 0);
            Instantiate(bullet, actual, Quaternion.identity);
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
        yield return new WaitForSeconds(1.3f);
        shoot = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) {
            playerLives.setVida(-1);
            Destroy(collision.gameObject);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
           
        }
    }
}
