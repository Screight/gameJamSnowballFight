using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowMan : Interactive
{
    [SerializeField] int m_ammo;
    [SerializeField] GameObject m_globalCanvas;
    [SerializeField] TMPro.TextMeshProUGUI m_interactTMP;

    [SerializeField] GameObject m_snowmanGO;
    [SerializeField] GameObject m_snowAmountGO;

    bool m_isSnowmanAlive = true;

    private void Awake()
    {
        m_globalCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
        m_globalCanvas.SetActive(false);
    }

    protected override void HandleInteraction()
    {
        if (m_isSnowmanAlive)
        {
            m_isSnowmanAlive = false;
            m_snowmanGO.SetActive(false);
            m_snowAmountGO.SetActive(true);
            m_interactTMP.text = "Charge";
        }
        else
        {
            GameManager.Instance.SnowballCounter += m_ammo;
            GameManager.Instance.SnowmanCounter--;
            Destroy(gameObject);
        }
    }

    protected override void OnTriggerEnter(Collider p_collider)
    {
        base.OnTriggerEnter(p_collider);
        if (p_collider.tag != "Player") { return; }
        m_globalCanvas.SetActive(true);
    }

    protected override void OnTriggerExit(Collider p_collider)
    {
        base.OnTriggerExit(p_collider);
        if (p_collider.tag != "Player") { return; }
        m_globalCanvas.SetActive(false);
    }
}
