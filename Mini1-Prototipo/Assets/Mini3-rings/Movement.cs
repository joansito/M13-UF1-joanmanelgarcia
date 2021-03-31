using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject aroBlack;
    public GameObject aroWhite;
    public GameObject refGiro;
    public float vGiro;
    Vector3 axis = new Vector3(0, 0, 1);
    // Start is called before the first frame update
    void Update()
    {
        instantiateAro();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 point = refGiro.transform.position;

        transform.RotateAround(point, axis, Time.deltaTime * vGiro);
      
    }

    private void instantiateAro() {
        if (Input.GetKeyUp("up"))
        {
            Instantiate(aroWhite, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        } else if (Input.GetKeyUp("down")) {
            Instantiate(aroBlack, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        }
    }
}
