using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUtils : MonoBehaviour
{
    [SerializeField] MenuManager m_pauseMenuManager;

    [SerializeField] GameObject m_hideOnMenuPause;

    public void OpenMenuPause()
    {
        if (m_pauseMenuManager.IsInStartScreen)
        {
            m_pauseMenuManager.GoTo(1);
            GameManager.Instance.PauseGame();
            m_hideOnMenuPause.SetActive(false);
        }
        else
        {
            m_hideOnMenuPause.SetActive(true);
            m_pauseMenuManager.ResetToStartScreen();
            GameManager.Instance.ResumeGame();
        }

    }

}
