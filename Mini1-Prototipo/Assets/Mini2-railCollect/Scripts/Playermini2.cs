using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermini2 : MonoBehaviour
{

    void Update()
    {
        controllerPlayer();
    }
    private void controllerPlayer() {

        if (Input.GetKeyDown("up"))
        {
            if (this.transform.position.y < -1f)
            {
                this.transform.position += new Vector3(0, 1);
            }

        }
        else if (Input.GetKeyDown("down"))
        {
            if (this.transform.position.y > -2.99f)
            {
                this.transform.position -= new Vector3(0, 1);
            }
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && (Input.GetKey("a") || Input.GetKey("right")))
        {
            Destroy(collision.gameObject);
            print("punto");
        }
       

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && (Input.GetKey("a") || Input.GetKey("right")))
        {
            Destroy(collision.gameObject);
            print("punto");
        }
    }

}
