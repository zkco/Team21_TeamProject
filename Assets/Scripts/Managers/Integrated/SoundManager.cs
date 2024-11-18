using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour,IManager
{
    public AudioSource sfxSource;       //sfx���� ����� ����
    public AudioSource bgmSource;       //bgm���� ����� ����

    //sfxŬ�� �����س��� Dic
    private Dictionary<Enum, AudioClip> soundDictionary = new Dictionary<Enum, AudioClip>();

    /// <summary>
    /// SFX ��� �Լ�
    /// </summary>
    public void PlaySFX(SFXType type)
    {
        sfxSource.PlayOneShot(soundDictionary[type]);
    }

    /// <summary>
    /// BGM ��� �Լ�
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
