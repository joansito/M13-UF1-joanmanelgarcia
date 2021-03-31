using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float giroVelocity = 1;
   public float delanteSpeed = 0.06f;
    public Rigidbody2D a;
    void FixedUpdate()
    {
        
        moveKeys();
    }
    private void moveKeys() {

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
        }
        else {
            this.transform.position = new Vector2(-4.9f, 0);
            print("teltransporte!!");
        }
        
    }
    
  
}
