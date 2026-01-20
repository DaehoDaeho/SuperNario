using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class AudioOptionsUI : MonoBehaviour
{
    [SerializeField]
    private GameObject optionPanel;

    [SerializeField]
    private AudioMixer mixer;

    [SerializeField]
    private string mainVolumeParam = "MainVolume";

    [SerializeField]
    private string bgmVolumeParam = "BGMVolume";

    [SerializeField]
    private string sfxVolumeParam = "SFXVolume";

    [SerializeField]
    private Slider mainSlider;

    [SerializeField]
    private Slider bgmSlider;

    [SerializeField]
    private Slider sfxSlider;

    private void Start()
    {
        optionPanel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) == true)
        {
            optionPanel.SetActive(!optionPanel.activeSelf);
        }
    }

    public void OnMainSlider(float value)
    {
        ApplyMixerVolume(mainVolumeParam, value);
    }

    public void OnBGMSlider(float value)
    {
        ApplyMixerVolume(bgmVolumeParam, value);
    }

    public void OnSFXSlider(float value)
    {
        ApplyMixerVolume(sfxVolumeParam, value);
    }

    void ApplyMixerVolume(string paramName, float value)
    {
        float safeValue = value;
        if (safeValue <= 0.0f)
        {
            safeValue = 0.0001f;
        }
        
        float db = Mathf.Log10(safeValue) * 20.0f;
        mixer.SetFloat("SFXVolume", db);
    }
}
