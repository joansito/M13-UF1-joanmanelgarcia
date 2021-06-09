using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Min6SimplyEnemy : MonoBehaviour
{

    public string direction;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x<-17|| this.transform.position.x > 17)
        {
            Destroy(this.gameObject);
        }
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
        else
        {
            this.transform.position += new Vector3(-speed, 0, 0);
        }

    }

   
}
