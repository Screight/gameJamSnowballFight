using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : Enemy
{

    [SerializeField] private float speed = 5f;

    [SerializeField] private float shoot_interval = 2f;

    [SerializeField] GameObject e_projectile;
    [SerializeField] float projectileSpeed;

    private void Update()
    {

        shoot_interval -= Time.deltaTime;

        //Debug.Log(shoot_interval);

        if (shoot_interval <= 0)
        {

            shoot();
            shoot_interval = 3f;
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

    void shoot()
    {
        Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;

        Projectile enemy_projectile = Instantiate(e_projectile, transform.position, Quaternion.identity).GetComponent<Projectile>();

        Vector3 direction = (pos - transform.position).normalized;

        enemy_projectile.Initialize(projectileSpeed, direction);
        //FireRate();
        //Destroy(enemy_projectile, 10);
    }

    //private IEnumerator FireRate()
    //{
    //    speed = 0;
    //    yield return new WaitForSeconds(shoot_interval);
    //    speed = 5f;
    //}
}
