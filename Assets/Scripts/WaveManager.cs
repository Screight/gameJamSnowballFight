using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    int m_currentWave = 0;

    [SerializeField] GameObject m_walkerEnemyPrefab;
    [SerializeField] GameObject m_shooterEnemyPrefab;
    [SerializeField] GameObject m_catapultEnemyPrefab;

    enum ENEMY_TYPE { WALKER, SHOOTER, CATAPULT}

    int[] m_maxNumberOfEnemiesCurrentWave;
    int[] m_currentNumberOfEnemiesCurrentWave;

    [SerializeField] float m_spawnTimePeriod = 2.0f;
    bool m_areAnyEnemyLeft = false;

    private void Awake()
    {
        m_maxNumberOfEnemiesCurrentWave = new int[3];
        m_currentNumberOfEnemiesCurrentWave = new int[3];
    }

    float m_currentTime = 0;

    private void Update()
    {
        if (m_areAnyEnemyLeft)
        {
            m_currentTime += Time.deltaTime;

            if(m_currentTime > m_spawnTimePeriod)
            {
                m_currentTime = 0;

            }
        }
    }

    void SpawnEnemies()
    {

    }

    void InitializeNextWave()
    {
        m_currentWave++;

        m_maxNumberOfEnemiesCurrentWave[(int)ENEMY_TYPE.WALKER] = 3 * m_currentWave + 1;
        m_maxNumberOfEnemiesCurrentWave[(int)ENEMY_TYPE.SHOOTER] = 2 * m_currentWave;
        m_maxNumberOfEnemiesCurrentWave[(int)ENEMY_TYPE.CATAPULT] = m_currentWave;

        for(int i = 0; i < m_currentNumberOfEnemiesCurrentWave.Length; i++)
        {
            m_currentNumberOfEnemiesCurrentWave[i] = 0;
        }
        m_areAnyEnemyLeft = true;
    }

    bool AreAnyEnemiesLeft()
    {
        for(int i = 0; i < m_currentNumberOfEnemiesCurrentWave.Length; i++)
        {
            if (m_currentNumberOfEnemiesCurrentWave[i] != m_maxNumberOfEnemiesCurrentWave[i]) {
                return true; 
            }
        }
        return false;
    }


}
