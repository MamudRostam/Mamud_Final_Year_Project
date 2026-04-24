using UnityEngine;
using UnityEngine.UI;
public class AudioSettingsUI : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;


    void Start()
    {
        if (Audiomanager.instance == null) return;

        masterSlider.onValueChanged.RemoveAllListeners();
        musicSlider.onValueChanged.RemoveAllListeners();
        sfxSlider.onValueChanged.RemoveAllListeners();

        masterSlider.value = Audiomanager.instance.masterVolume;
        musicSlider.value = Audiomanager.instance.musicVolume;
        sfxSlider.value = Audiomanager.instance.sfxVolume;

        masterSlider.onValueChanged.AddListener(SetMaster);
        musicSlider.onValueChanged.AddListener(SetMusic);
        sfxSlider.onValueChanged.AddListener(SetSFX);
    }

    void SetMaster(float v)
    {
        Audiomanager.instance.masterVolume = v;
        Audiomanager.instance.ApplyVolume();

    }

    void SetMusic(float v)
    {
        Audiomanager.instance.musicVolume = v;
        Audiomanager.instance.ApplyVolume();

    }

    void SetSFX(float v)
    {
        Audiomanager.instance.sfxVolume = v;
        Audiomanager.instance.ApplyVolume();

    }



}
