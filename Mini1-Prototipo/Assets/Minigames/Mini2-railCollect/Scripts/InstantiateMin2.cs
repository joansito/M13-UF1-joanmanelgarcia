using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMin2 : MonoBehaviour
{
    float time;
    float[] enemyPositions;
    float[] obstaclePositions;
    public GameObject enemy;
    bool firstobstacle;
    int lastInstance = 20;
    // Start is called before the first frame update

    void Start()
    {

        firstobstacle = false;
        obstaclePositions = new float[3];
       obstaclePositions[0] = -2.33f;
        obstaclePositions[1] = -4.19f;
        obstaclePositions[2] = -3.24f;


        enemyPositions = new float[3];
        enemyPositions[0] = -2.8f;
        enemyPositions[1] = -1.82f;
        enemyPositions[2] = -3.61f;
        Invoke("InstantiateEnemy", 4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InstantiateEnemy()
    {
        if (enemy.tag == "Enemy")
        {

            int ramdPosition = Random.RandomRange(0, 2);
            time = Random.Range(1, 3);
            Vector3 posicion = new Vector3(11.64f, enemyPositions[ramdPosition], 0f);
            Instantiate(enemy, posicion, Quaternion.identity);
            Invoke("InstantiateEnemy", time);
        }
        else if (enemy.tag == "Obstacle") {
            if (!firstobstacle)
            {
                firstobstacle = true;
                time = Random.Range(4, 7);
                Invoke("InstantiateEnemy", time);
            }
            else
            {
                int ramdPosition = Random.RandomRange(0, 3);
                while(lastInstance == ramdPosition) {
                    ramdPosition = Random.RandomRange(0, 3);
                }
                print(ramdPosition.ToString());
                lastInstance = ramdPosition;
                time = Random.Range(3, 6);
                Vector3 posicion = new Vector3(11.64f, obstaclePositions[ramdPosition], 0f);
                Instantiate(enemy, posicion, Quaternion.identity);
                Invoke("InstantiateEnemy", time);
            }
          
        }
      




    }
}
