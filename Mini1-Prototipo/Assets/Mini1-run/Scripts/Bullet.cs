using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D a;
    public GameObject player;

    public float delanteSpeed = 0.06f;
    // Start is called before the first frame update
    void Start()
    {
        var dir = player.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward.normalized);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        a.AddForce(transform.right.normalized * delanteSpeed);
        a.velocity = a.velocity.normalized * delanteSpeed;
    }
}
