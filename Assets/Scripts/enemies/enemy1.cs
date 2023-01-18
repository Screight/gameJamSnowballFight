using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : Enemy
{

    [SerializeField] private float speed = 10f;

    private void Update()
    {
        Movement();
    }

    void Movement() { 

        Vector3 direction = new Vector3(0, 0, 1);

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
