using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Min6EnemyScript : MonoBehaviour
{
    GameObject player;
    public float vGiro;
    private float angle;
    private Vector2 dir;
    public float delanteSpeed = 0.06f;
    public Rigidbody2D a;
    void Start()
    {
        player = GameObject.Find("player");

    }
    public void Update()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        dir = player.transform.position - transform.position;

        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 180;


        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward.normalized * vGiro);

        if (dir.x/2 != 2f) {
            a.AddForce(-transform.right.normalized * delanteSpeed);
            a.velocity = a.velocity.normalized * delanteSpeed;
        }
       
    }
}
