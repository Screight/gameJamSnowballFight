using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Interactive : MonoBehaviour
{
    bool m_canBeActivated = false;

    private void OnEnable()
    {
        if (m_canBeActivated)
        {
            PlayerInputManager.Instance.AddListenerToReloadEvent(HandleInteraction);
        }
    }

    private void OnDisable()
    {
        if (m_canBeActivated)
        {
            PlayerInputManager.Instance.RemoveListenerFromReloadEvent(HandleInteraction);
        }
    }

    protected virtual void OnTriggerEnter(Collider p_collider)
    {
        if (p_collider.tag != "Player") { return; }
        m_canBeActivated = true;
        PlayerInputManager.Instance.AddListenerToReloadEvent(HandleInteraction);
    }

    protected virtual void OnTriggerExit(Collider p_collider)
    {
        if (p_collider.tag != "Player") { return; }
        m_canBeActivated = false;
        PlayerInputManager.Instance.RemoveListenerFromReloadEvent(HandleInteraction);
    }

    protected abstract void HandleInteraction();

}

