using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Projectile : MonoBehaviour
{
    [SerializeField] float m_speed;
    Vector3 m_direction;

    private void Awake()
    {
        Destroy(gameObject, 5.0f);
    }

    public void Initialize(float p_speed, Vector3 p_direction)
    {
        m_speed = p_speed;
        m_direction = p_direction;
    }

    private void Update()
    {
        transform.position += m_direction * m_speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "destino_bola_grande")
        {
            Destroy(gameObject);
        }
    }
}
