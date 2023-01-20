using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] int m_maxHealth = 10;
    int m_health;
    int m_score;
    int m_snowballCounter;

    int m_snowmanCounter;

    [SerializeField] TMPro.TextMeshProUGUI m_scoreText;
    [SerializeField] TMPro.TextMeshProUGUI m_healthText;
    [SerializeField] TMPro.TextMeshProUGUI m_snowballCounterText;

    protected override void Awake()
    {
        base.Awake();
        Health = m_maxHealth;
    }

    public int Health { 
        get { return m_health; }
        set {
            m_health = value;
            m_healthText.text = "Health " + m_health.ToString();
        } 
    }

    public int Score
    {
        get { return m_score; }
        set {
            m_score = value;
            m_scoreText.text = "Score: " + m_score.ToString();
        }
    }

    public int SnowballCounter
    {
        get { return m_snowballCounter; }
        set
        {
            m_snowballCounter = value;
            m_snowballCounterText.text = m_snowballCounter.ToString();
        }
    }

    public int SnowmanCounter
    {
        get { return m_snowmanCounter; }
        set { m_snowmanCounter = value; }
    }
}
