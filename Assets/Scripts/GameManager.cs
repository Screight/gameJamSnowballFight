using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] int m_maxHealth = 10;
    int m_health;
    int m_score;

    [SerializeField] TMPro.TextMeshProUGUI m_scoreText;
    [SerializeField] TMPro.TextMeshProUGUI m_healthText;

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

}
