using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixLevel : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Slider mstrSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;


    private void Start()
    {
        LoadVolumePreferences();
    }


    public void SetsfxVol(float sfxVol)
    {
        masterMixer.SetFloat("sfxVol", Mathf.Log10(sfxVol)*20);
        PlayerPrefs.SetFloat("sfxVol", sfxVol);
        Debug.Log("master " + PlayerPrefs.GetFloat("masterVol"));
    }
    public void SetbgmVol(float bgmVol)
    {
        masterMixer.SetFloat("bgmVol", Mathf.Log10(bgmVol) * 20);
        PlayerPrefs.SetFloat("bgmVol", bgmVol);
    }

    public void SetmstrVol(float mstrVol)
    {
        masterMixer.SetFloat("masterVol", Mathf.Log10(mstrVol) * 20);
        PlayerPrefs.SetFloat("masterVol", mstrVol);
    }

    void LoadVolumePreferences()
    {
        if (PlayerPrefs.HasKey("masterVol"))
        {
            float mstrVol = PlayerPrefs.GetFloat("masterVol");
            mstrSlider.value = mstrVol;
            SetmstrVol(mstrVol);
           
        }
        if (PlayerPrefs.HasKey("bgmVolVol"))
        {
            SetmstrVol(Mathf.Log10(PlayerPrefs.GetFloat("bgmVol")) * 20);
        }
        if (PlayerPrefs.HasKey("sfxVol"))
        {
            SetmstrVol(Mathf.Log10(PlayerPrefs.GetFloat("sfxVol")) * 20);
        }
    }
}
