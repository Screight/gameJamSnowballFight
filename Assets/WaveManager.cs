using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    int m_numberOfWave = 0;

    [SerializeField] GameObject m_walkerEnemyPrefab;
    [SerializeField] GameObject m_shooterEnemyPrefab;
    [SerializeField] GameObject m_catapultEnemyPrefab;

    public void InitializeNextWave()
    {
        m_numberOfWave++;
    }

}
