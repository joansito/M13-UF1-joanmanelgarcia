using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMoveElmnts : MonoBehaviour
{
    public float speed;
    public float posIni,posFinal;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.position.x <= posFinal) {
            this.transform.position = new Vector3(posIni, -0.5569038f);
        }
        this.transform.position -= new Vector3(speed, 0);
    }
}
