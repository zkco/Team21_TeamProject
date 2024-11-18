using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour,IManager
{
    public AudioSource sfxSource;       //sfx전용 오디오 변수
    public AudioSource bgmSource;       //bgm전용 오디오 변수

    //sfx클립 저장해놓는 Dic
    private Dictionary<Enum, AudioClip> soundDictionary = new Dictionary<Enum, AudioClip>();

    /// <summary>
    /// SFX 재생 함수
    /// </summary>
    public void PlaySFX(SFXType type)
    {
        sfxSource.PlayOneShot(soundDictionary[type]);
    }

    /// <summary>
    /// BGM 재생 함수
    /// </summary>
    public void PlayBGM(BGMType type)
    {
        if (bgmSource.clip == soundDictionary[type])
            return;

        bgmSource.clip = soundDictionary[type];
        bgmSource.Play();
    }
    public void Init()
    {
        
    }
}
