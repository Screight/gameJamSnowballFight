using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int m_maxHealth = 5;
    int m_health;

    private void Awake()
    {
        m_health = m_maxHealth;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "player_projectile") return;
        m_health--;
        if (m_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "player_projectile") return;
        m_health--;
        if(m_health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
