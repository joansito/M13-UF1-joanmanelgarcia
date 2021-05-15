using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMin1Script : MonoBehaviour
{
    GameObject player;
    public float vGiro;
    private float angle;
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.Find("player");
        InvokeRepeating("InstantiateBullet", 3.0f, 2.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         dir = player.transform.position - transform.position;
      
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 180;
        
        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward.normalized*vGiro);

    }

    private void InstantiateBullet() {

        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.transform.right = transform.right.normalized;
            bullet.SetActive(true);
        }

    }
}
