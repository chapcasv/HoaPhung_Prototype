using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSystem : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] GameObject setting_popUp;

    private const string keyNameVolume = "volume";

    private void Awake()
    {
        UnActiveUI();
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey(keyNameVolume))
        {
            PlayerPrefs.SetFloat(keyNameVolume,1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    private void LoadVolume()
    {
       volumeSlider.value = PlayerPrefs.GetFloat(keyNameVolume);
        ChangeVolume();
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat(keyNameVolume, volumeSlider.value);
        ChangeVolume();
    }

    public void SaveSetting()
    {
        SaveVolume();
        //SaveScreenSize;
        //SaveGameLanguage;
        UnActiveUI();
    }

    public void LoadSetting()
    {
        LoadVolume();
        //LoadScreenSize;
        //LoadGameLanguage;
        ActiveUI();
    }

    public void CancelSetting()
    {
        //Need dialog Yes No to know player want to save after close?
        UnActiveUI();
    }

    private void ActiveUI()
    {
        setting_popUp.SetActive(true);
    }

    private void UnActiveUI()
    {
        setting_popUp.SetActive(false);
    }
}
