using UnityEngine;
using UnityEngine.UI;
public class AudioSettingsUI : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;


    void Start()
    {
        masterSlider.onValueChanged.AddListener(SetMaster);
        musicSlider.onValueChanged.AddListener(SetMusic);
        sfxSlider.onValueChanged.AddListener(SetSFX);
    }

    void SetMaster(float v)
    {
        Audiomanager.instance.masterVolume = v;
    }

    void SetMusic(float v)
    {
        Audiomanager.instance.musicVolume = v;
    }

    void SetSFX(float v)
    {
        Audiomanager.instance.sfxVolume = v;
    }


}
