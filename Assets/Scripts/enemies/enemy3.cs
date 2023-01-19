using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : Enemy
{

    private bool stopped;
    private bool canShoot = false;

    [SerializeField] private float speed = 3f;

    [SerializeField] float shoot_interval_publico;
    private float shoot_interval;

    private float x;
    private float z;

    [SerializeField] GameObject e_projectile;
    [SerializeField] float projectileSpeed;

    private void Update()
    {

        if (!stopped) {
            Movement();
        }
        else
        {
            shoot_interval -= Time.deltaTime;

            if (shoot_interval <= 0 && canShoot)
            {
                shoot();
                shoot_interval = shoot_interval_publico;
            }
        }
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
            stopped = true;
            canShoot = true;
        }
    }
    
    void shoot() {
        Debug.Log("disparo desde shoot()");
        Big_Projectile enemy_projectile = Instantiate(e_projectile, transform.position, Quaternion.identity).GetComponent<Big_Projectile>();
        enemy_projectile.Initialize(projectileSpeed, Vector3.up);
        FireRate();
    }

    private IEnumerator FireRate()
    {
        canShoot = false;
        yield return new WaitForSeconds(shoot_interval);
        Big_Projectile enemy_projectile = Instantiate(e_projectile, new Vector3(), Quaternion.identity).GetComponent<Big_Projectile>();
        enemy_projectile.Initialize(projectileSpeed, Vector3.down);

        canShoot = true;
    }
}
