using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : MonoBehaviour
{

    private float speed = 5f;

    private void Update()
    {
        Movement();
    }

    void Movement()
    {

        Vector3 direction = new Vector3(0, 0, 1);

        transform.Translate(direction * speed * Time.deltaTime);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "limite_catapulta")
        {
            Debug.Log("colisión epica");
            speed = 0f;
        }
    }
}
