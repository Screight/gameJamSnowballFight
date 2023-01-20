using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    int m_currentWave = 0;

    [SerializeField] GameObject m_walkerEnemyPrefab;
    [SerializeField] GameObject m_shooterEnemyPrefab;
    [SerializeField] GameObject m_catapultEnemyPrefab;

    GameObject[] m_enemies;

    enum ENEMY_TYPE { WALKER, SHOOTER, CATAPULT}

    int[] m_maxNumberOfEnemiesCurrentWave;
    int[] m_currentNumberOfEnemiesCurrentWave;

    [SerializeField] float m_spawnTimePeriod = 2.0f;
    bool m_areAnyEnemyLeft = false;

    private void Awake()
    {
        m_maxNumberOfEnemiesCurrentWave = new int[3];
        m_currentNumberOfEnemiesCurrentWave = new int[3];
        m_enemies = new GameObject[3];
        m_enemies[(int)ENEMY_TYPE.WALKER] = m_walkerEnemyPrefab;
        m_enemies[(int)ENEMY_TYPE.SHOOTER] = m_shooterEnemyPrefab;
        m_enemies[(int)ENEMY_TYPE.CATAPULT] = m_catapultEnemyPrefab;
    }

    private void Start()
    {
        InitializeNextWave();
    }

    float m_currentTime = 0;

    private void Update()
    {
        if (AreAnyEnemiesLeft())
        {
            m_currentTime += Time.deltaTime;

            if(m_currentTime > m_spawnTimePeriod)
            {
                m_currentTime = 0;
                SpawnEnemies();
            }
        }
        else
        {
            m_timeNextWave += Time.deltaTime;
            GameManager.Instance.SetWaveCounter((int)m_periodNextWave - (int)m_timeNextWave);
            if (m_timeNextWave >= m_periodNextWave)
            {
                m_timeNextWave = 0;
                InitializeNextWave();
                GameManager.Instance.SetWaveCounter(0);
            }
        }
    }

    float m_timeNextWave;
    float m_periodNextWave = 5;

    [SerializeField] BoxCollider m_spawnCollider;

    Vector3 GetRandomPosition()
    {
        Vector3 spawnPosition;
        spawnPosition.x = Random.Range(m_spawnCollider.transform.position.x - m_spawnCollider.size.x / 2, m_spawnCollider.transform.position.x + m_spawnCollider.size.x / 2);
        spawnPosition.y = 0;
        spawnPosition.z = Random.Range(m_spawnCollider.transform.position.z - m_spawnCollider.size.z / 2, m_spawnCollider.transform.position.z + m_spawnCollider.size.z / 2);

        return spawnPosition;
    }

    void SpawnEnemies()
    {
        int numberOfEnemies = Random.Range(2,3);
        int rndInt = 0;

        for(int i = 0; i < numberOfEnemies && AreAnyEnemiesLeft(); i++)
        {
            Vector3 spawnPosition = GetRandomPosition();
            rndInt = Random.Range(0, 3);

            while (m_currentNumberOfEnemiesCurrentWave[rndInt] == m_maxNumberOfEnemiesCurrentWave[rndInt])
            {
                rndInt = Random.Range(0, 3);
            }
            Instantiate(m_enemies[rndInt], spawnPosition, m_enemies[rndInt].transform.rotation);
            m_currentNumberOfEnemiesCurrentWave[rndInt]++;
        }

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
        GameManager.Instance.SetWaveCounterTo(m_currentWave);
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
