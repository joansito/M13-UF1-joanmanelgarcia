using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMini5 : MonoBehaviour
{
    public Rigidbody2D a;
    public float delanteSpeed = 0.06f;
    public GameObject bullet;
    bool pulsado;
    // Start is called before the first frame update
    void Start()
    {
        pulsado = false;
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
        else
        {
            a.velocity *= 0;
            pulsado = false;
        }
    }
    IEnumerator shoot()
    {
        if (Input.GetKey("right") && !pulsado)
        {
            yield return new WaitForSeconds(1f);
        }
    }
}
