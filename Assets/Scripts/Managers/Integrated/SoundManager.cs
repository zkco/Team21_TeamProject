using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour,IManager
{
    public AudioSource sfxSource;       //sfx���� ����� ����
    public AudioSource bgmSource;       //bgm���� ����� ����

    //sfxŬ�� �����س��� Dic
    private Dictionary<Enum, AudioClip> clipDictionary = new Dictionary<Enum, AudioClip>();

    /// <summary>
    /// SFX ��� �Լ�
    /// </summary>
    public void PlaySFX(SfxType type)
    {
        sfxSource.PlayOneShot(clipDictionary[type]);
    }

    /// <summary>
    /// BGM ��� �Լ�
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
