using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    
    public AudioClip themesong, fightsong;
    public AudioSource adisrc;
    public static SoundManager instance;

    private string themeSong = "HoaPhung_theme";
    private string fightSong = "HoaPhung_fight";
    private const string theme = "theme";
    private const string fight = "fight";

    void Awake()
    {   
        if(instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        themesong = Resources.Load<AudioClip>(themeSong);
        fightsong = Resources.Load<AudioClip>(fightSong);
        adisrc = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlaySound(theme);
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case theme:
                adisrc.clip = themesong;
                adisrc.Play();
                break;

            case fight:
                adisrc.clip = fightsong;
                adisrc.Play();
                break;
        }
    }
    
}
