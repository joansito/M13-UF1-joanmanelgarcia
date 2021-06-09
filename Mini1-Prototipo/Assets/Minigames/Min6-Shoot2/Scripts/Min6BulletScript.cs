using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Min6BulletScript : MonoBehaviour
{
    public float speed;
    public string direction;
    ScorePoints playerPoints;
    void Start()
    {
        playerPoints = GameObject.FindGameObjectWithTag("ScoreBar").GetComponent<ScorePoints>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        if (direction == "right")
        {
            this.transform.position += new Vector3(speed, 0, 0);
        }
        else {
            this.transform.position += new Vector3(-speed, 0, 0);
        }
        
    }

    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 9)
        {
            playerPoints.setPuntos(100);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer ==10)
        {
            playerPoints.setPuntos(100);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            playerPoints.setPuntos(100);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
