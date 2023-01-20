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

    [SerializeField] MenuManager m_menuManager;
    Image m_menuOverlay;

    private void OnEnable()
    {
        PlayerInputManager.Instance.AddListenerToPauseEvent(PauseUnPauseGame);
    }

    private void Start()
    {
        m_menuOverlay = m_menuManager.GetComponent<Image>();
    }

    public void PauseUnPauseGame()
    {
        if (m_isGamePaused) { ResumeGame(); }
        else { PauseGame(); }
    }

    bool m_isGamePaused;
    public void PauseGame()
    {
        Time.timeScale = 0;
        m_isGamePaused = true;
        m_menuManager.GoTo(1);
        m_menuOverlay.enabled = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        m_isGamePaused = false;
        m_menuManager.GoTo(0);
        m_menuOverlay.enabled = false;
    }

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
