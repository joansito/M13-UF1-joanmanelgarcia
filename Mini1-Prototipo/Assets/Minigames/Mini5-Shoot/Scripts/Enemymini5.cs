using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymini5 : MonoBehaviour
{
    private float speed;

    HealthbarScript playerLives;
    void Start()
    {
        playerLives = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthbarScript>();
        speed = Random.Range(0.10f, 0.20f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        move();
    }
    public void Update()
    {
        if (this.transform.position.y < -4) {
            playerLives.setVida(-1);
            Destroy(this.gameObject);
        }
    }
    private void move()
    {
        this.transform.position += new Vector3(0, -speed, 0);
    }
    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

  
}
