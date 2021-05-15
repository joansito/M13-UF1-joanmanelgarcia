using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaPlayerScript : MonoBehaviour
{
    public Rigidbody2D a;
    MapaFase1Script fase1Script;
    public float delanteSpeed = 0.06f;
    bool pulsado;
    void Start()
    {
        fase1Script = GameObject.FindGameObjectWithTag("Fase").GetComponent<MapaFase1Script>();
        pulsado = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveKeys();
    }

    private void moveKeys()
    {
        if (Input.GetKey("right") && !pulsado)
        {
            pulsado = true;
            a.AddForce(transform.right.normalized * delanteSpeed);
            a.velocity = a.velocity.normalized * delanteSpeed;
        }
        else if (Input.GetKey("left") && !pulsado)
        {
            pulsado = true;
            a.AddForce(-transform.right.normalized * delanteSpeed);
            a.velocity = a.velocity.normalized * delanteSpeed;
        }
        else if (Input.GetKey("up") && !pulsado)
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
        else
        {
            a.velocity *= 0;
            pulsado = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {

            SceneManager.LoadScene(6);
            fase1Script.setCompletado();
        }
        else if (collision.gameObject.layer == 4)
        {

            SceneManager.LoadScene(6);
            fase1Script.setCompletado();
        }
        else if (collision.gameObject.layer == 12)
        {
            switch (collision.gameObject.name)
            {
                case "1-1":
                    SceneManager.LoadScene(11);
                    break;
                case "2-1":
                    SceneManager.LoadScene(12);
                    break;
                case "3-1":
                    SceneManager.LoadScene(13);
                    break;
                case "Min1": //cambiar este porque es el ultimo minijuego*/
                    SceneManager.LoadScene(2);
                    break;
                case "Min2":
                    SceneManager.LoadScene(3);
                    break;
            }
        }
        else if (collision.gameObject.layer == 13) {
            SceneManager.LoadScene(1);
        }
    }

}
