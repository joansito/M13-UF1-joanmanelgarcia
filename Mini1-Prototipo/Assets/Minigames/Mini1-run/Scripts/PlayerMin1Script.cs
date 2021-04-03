using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMin1Script : MonoBehaviour
{
   public float giroVelocity = 1;
   public float delanteSpeed = 0.06f;
   public Rigidbody2D a;
   bool muerto;

   HealthbarScript playerLives;
    ScorePoints playerPoints;
    CollectionableBar playerObjects;
    public void Start()
    {
        playerLives = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthbarScript>();
        playerPoints= GameObject.FindGameObjectWithTag("ScoreBar").GetComponent<ScorePoints>();
        playerObjects = GameObject.FindGameObjectWithTag("CollectionableBar").GetComponent<CollectionableBar>();
    }
    void FixedUpdate()
    {
        muerto = playerLives.getMuerte();
        if (muerto) { print("muerto"); }
        moveKeys();
    }
    private void moveKeys() {

        if (Input.GetKey("a")) {
            playerLives.setVida(-1);
            print("A!!");
        }

        if (Input.GetKey("right"))
        {
            transform.eulerAngles -= Vector3.forward * giroVelocity;
            a.AddForce(transform.up.normalized * delanteSpeed*7);
            a.velocity = a.velocity.normalized * delanteSpeed;
        }
        else if (Input.GetKey("left"))
        {
            a.AddForce(transform.up.normalized * delanteSpeed*7);
            a.velocity = a.velocity.normalized * delanteSpeed;
            transform.eulerAngles += Vector3.forward * giroVelocity;
        }
        else {
            a.AddForce(transform.up.normalized * delanteSpeed);
            a.velocity = a.velocity.normalized * delanteSpeed;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) {
            Destroy(collision.gameObject);
            print("punto");
            playerPoints.setPuntos(100);
            playerObjects.setColeccionable(1);

        } else if (collision.gameObject.layer==9) {
            Destroy(collision.gameObject);
            print("disparorecibido");
            if (!muerto)
            {
                playerLives.setVida(-1);
            }
        }else {
            this.transform.position = new Vector2(-4.9f, 0);
            print("teltransporte!!");
        }
        
    }
    
  
}
