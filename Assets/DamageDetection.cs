using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "enemy") return;

        GameManager.Instance.Health -= other.GetComponent<Enemy>().DamageOnCollision;

    }
}
