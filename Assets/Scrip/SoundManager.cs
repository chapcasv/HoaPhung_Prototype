using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip themesong, fightsong;

    public AudioSource adisrc;
    public static SoundManager instance;
    // Start is called before the first frame update
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

        themesong = Resources.Load<AudioClip>("HoaPhung_theme");
        fightsong = Resources.Load<AudioClip>("HoaPhung_fight");
        adisrc = GetComponent<AudioSource>();
    }
    private void Start()
    {
        PlaySound("theme");
    }
    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "theme":
                adisrc.clip = themesong;
                adisrc.Play();
                
                break;

            case "fight":

                adisrc.clip = fightsong;
                adisrc.Play();
                break;
        }
    }
    
}
