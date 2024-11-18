using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour,IManager
{
    public AudioSource sfxSource;       //sfx전용 오디오 변수
    public AudioSource bgmSource;       //bgm전용 오디오 변수

    //sfx클립 저장해놓는 Dic
    private Dictionary<Enum, AudioClip> clipDictionary = new Dictionary<Enum, AudioClip>();

    /// <summary>
    /// SFX 재생 함수
    /// </summary>
    public void PlaySFX(SfxType type)
    {
        sfxSource.PlayOneShot(clipDictionary[type]);
    }

    /// <summary>
    /// BGM 재생 함수
    /// </summary>
    public void PlayBGM(BgmType type)
    {
        if (bgmSource.clip == clipDictionary[type])
            return;

        bgmSource.clip = clipDictionary[type];
        bgmSource.Play();
    }
    public void Init()
    {
        
    }
}
