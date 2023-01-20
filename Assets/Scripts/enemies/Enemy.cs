using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int m_maxHealth = 5;
    [SerializeField] int m_damageOnCollision = 2;
    protected int m_health;

    [SerializeField] protected int m_score;

    private void Awake()
    {
        m_health = m_maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Player") {
            GameManager.Instance.Health -= m_damageOnCollision;
            Destroy(gameObject);
        }
    }

    public int DamageOnCollision
    {
        get { return m_damageOnCollision; }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
