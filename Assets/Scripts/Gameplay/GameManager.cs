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

    [SerializeField] TMPro.TextMeshProUGUI m_waveCounterText;
    [SerializeField] TMPro.TextMeshProUGUI m_nextWaveCounterText;

    [SerializeField] MenuManager m_menuManager;
    [SerializeField] GameObject[] m_gameUI;
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
        foreach(GameObject gO in m_gameUI)
        {
            gO.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        m_isGamePaused = false;
        m_menuManager.GoTo(0);
        m_menuOverlay.enabled = false;
        foreach (GameObject gO in m_gameUI)
        {
            gO.SetActive(true);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        Health = m_maxHealth;
    }

    [SerializeField] TMPro.TextMeshProUGUI m_lastScoreText;
    [SerializeField] TMPro.TextMeshProUGUI m_gameOverText;

    public int Health { 
        get { return m_health; }
        set {
            m_health = value;
            m_healthText.text = "Health " + m_health.ToString();

            if(m_health <= 0)
            {
                m_lastScoreText.gameObject.SetActive(true);
                m_gameOverText.gameObject.SetActive(true);

                Time.timeScale = 0;
                m_lastScoreText.text = m_score.ToString();
                foreach (GameObject gO in m_gameUI)
                {
                    gO.SetActive(false);
                }
            }

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

    public void SetWaveCounterTo(int p_value)
    {
        m_waveCounterText.text = "Wave " + p_value;
    }

    public void SetWaveCounter(int p_value)
    {
        if(p_value == 0)
        {
            m_nextWaveCounterText.text = "";
        }
        else
        {
            m_nextWaveCounterText.text = p_value.ToString();
        }
    }

    public int SnowmanCounter
    {
        get { return m_snowmanCounter; }
        set { m_snowmanCounter = value; }
    }
}
