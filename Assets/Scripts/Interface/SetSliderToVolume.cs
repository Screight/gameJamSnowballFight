using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSliderToVolume : MonoBehaviour
{
    [SerializeField] Slider m_masterVolume;
    [SerializeField] Slider m_effectVolume;
    [SerializeField] Slider m_musicVolume;

    private void OnEnable()
    {
        if (AudioManager.IsNull) { return; }
        m_masterVolume.value = AudioManager.Instance.GetMasterVolume();
        m_effectVolume.value = AudioManager.Instance.GetEffectVolume();
        m_musicVolume.value = AudioManager.Instance.GetMusicVolume();
    }

}
