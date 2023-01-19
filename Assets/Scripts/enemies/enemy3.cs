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

    private BoxCollider x;

    [SerializeField] GameObject sombra;
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
        Destroy(enemy_projectile.gameObject, 3f);
        StartCoroutine(FireRate());
    }

    private IEnumerator FireRate()
    {
        x = GameObject.FindGameObjectWithTag("destino_bola_grande").GetComponent<BoxCollider>();
        
        canShoot = false;
        yield return new WaitForSeconds(shoot_interval_publico);

        Vector3 spawnPosition;
        spawnPosition.x = Random.Range(x.transform.position.x - x.size.x/2, x.transform.position.x + x.size.x / 2);
        spawnPosition.y = 22;
        spawnPosition.z = Random.Range(x.transform.position.z - x.size.z/2, x.transform.position.z + x.size.z / 2);

        Big_Projectile enemy_projectile_down = Instantiate(e_projectile, spawnPosition, Quaternion.identity).GetComponent<Big_Projectile>();
        Debug.Log("bola grande para abajo");
        enemy_projectile_down.Initialize(projectileSpeed, Vector3.down);

        Vector3 floor = transform.TransformDirection(Vector3.down);
        RaycastHit hit;

        Vector3 shadowPosition;
        shadowPosition.x = spawnPosition.x;
        shadowPosition.y = 0.01f;
        shadowPosition.z = spawnPosition.z;

        if (Physics.Raycast(enemy_projectile_down.transform.position, floor, out hit, 23))
        {
            Debug.Log(hit.transform.tag);
            GameObject b_sombra = Instantiate(sombra, shadowPosition, sombra.transform.rotation);
            enemy_projectile_down.sombra = b_sombra;
        }

        canShoot = true;
    }
}
