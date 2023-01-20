using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject[] m_screens;
    Stack<GameObject> m_stack = new Stack<GameObject>();

    [SerializeField] GameObject m_startScreen;

    int m_currentScreenIndex;
    int m_lastScreenIndex;

    private void Start()
    {
        m_stack.Push(m_startScreen);
        for (int i = 0; i < m_screens.Length; i++)
        {
            m_screens[i].SetActive(false);
        }
        m_startScreen.SetActive(true);
        m_currentScreenIndex = 0;
        m_lastScreenIndex = 0;
    }

    public void GoTo(int i)
    {
        if (i < 0 || i > m_screens.Length) { return; }
        if (m_stack.Peek() == m_screens[i]) { return; }
        if (m_stack.Contains(m_screens[i]))
        {
            while (m_stack.Peek() != m_screens[i])
            {
                m_stack.Pop().SetActive(false);
            }
            m_stack.Peek().SetActive(true);
        }
        else
        {
            m_stack.Peek().SetActive(false);
            m_stack.Push(m_screens[i]);
            m_screens[i].SetActive(true);
        }
        m_lastScreenIndex = m_currentScreenIndex;
        m_currentScreenIndex = i;
    }

    public void GoBack()
    {
        if (m_stack.Count <= 1) { return; }
        m_stack.Pop().SetActive(false);
        m_stack.Peek().SetActive(true);

        int temp = m_lastScreenIndex;
        m_lastScreenIndex = m_currentScreenIndex;
        m_currentScreenIndex = temp;
    }

    public void ResetToStartScreen()
    {
        foreach (GameObject screenGO in m_screens)
        {
            screenGO.SetActive(false);
        }
        m_startScreen.SetActive(true);
        m_stack.Clear();
        m_stack.Push(m_startScreen);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public bool IsInStartScreen { get { return m_stack.Peek() == m_startScreen; } }
    public int CurrentScreenIndex { get { return m_currentScreenIndex; } }

}
