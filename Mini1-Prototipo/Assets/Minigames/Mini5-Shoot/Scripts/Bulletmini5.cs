using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmini5 : MonoBehaviour
{
    ScorePoints playerPoints;
    public float speed;
    void Start()
    {
        playerPoints = GameObject.FindGameObjectWithTag("ScoreBar").GetComponent<ScorePoints>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }
    private void move() {
        this.transform.position += new Vector3(0,speed,0);
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
