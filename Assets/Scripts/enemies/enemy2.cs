using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{

    private float speed = 7f;

    private float shoot_interval = 3f;

    private void Update()
    {
        shoot_interval -= Time.deltaTime;

        //Debug.Log(shoot_interval);

        if (shoot_interval <= 0) {

            //shoot();
            //yield return new WaitForSeconds(shoot_interval);
        }
        else
        {
            Movement();
        }
    }

    void Movement()
    {

        Vector3 direction = new Vector3(0, 0, 1);

        transform.Translate(direction * speed * Time.deltaTime);


    }

    void shoot() {
        
    }
}
