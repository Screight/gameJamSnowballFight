using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanDie : MonoBehaviour
{
    [SerializeField] SnowMan m_snowmanScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "player_projectile" && other.tag != "enemy_projectile") return;
        Destroy(other.gameObject);
        m_snowmanScript.Damage();
    }

}
