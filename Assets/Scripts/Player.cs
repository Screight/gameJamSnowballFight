using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float m_movementSpeed;
    [SerializeField] float m_projectileSpeed;

    CharacterController m_controller;

    [SerializeField] GameObject m_projectilePrefab;

    [SerializeField] Transform m_throwBallPositionTr;

    private void OnEnable()
    {
        PlayerInputManager.Instance.AddListenerToShootEvent(Shoot);
    }

    private void OnDisable()
    {
        PlayerInputManager.Instance.RemoveListenerFromShootEvent(Shoot);
    }

    private void Awake()
    {
        m_controller = GetComponent<CharacterController>();
    }

    private void Update()
    {

        Vector3 movement;

        Vector2 input = PlayerInputManager.Instance.MovementInput;

        movement.x = input.x;
        movement.y = 0;
        movement.z = input.y;

        m_controller.Move(movement * m_movementSpeed * Time.deltaTime);

    }

    void Shoot()
    {
        Projectile projectile =  Instantiate(m_projectilePrefab, m_throwBallPositionTr.position, Quaternion.identity).GetComponent<Projectile>();
        projectile.Initialize(m_projectileSpeed, Vector3.forward);
    }

}
