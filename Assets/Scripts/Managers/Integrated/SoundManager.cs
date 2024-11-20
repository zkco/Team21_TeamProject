using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SoundManager : MonoBehaviour,IManager
{
    public AudioSource sfxSource;       //sfx���� ����� ����
    public AudioSource bgmSource;       //bgm���� ����� ����

    //�Ҹ� �����س��� Dictionary
    private Dictionary<Enum, AudioClip> soundDictionary = new Dictionary<Enum, AudioClip>();

    /// <summary>
    /// SFX ��� �Լ�
    /// </summary>
    public void PlaySFX(SFXType type)
    {
        //�ѹ��� ���.(�ٸ� ������ �������̿��� ���� ����)
        //play = �ٸ� ������ �������̸� ���� �� ����

        //loop�� false�� ���
        //play�� ������ ������ ������̸� �ش� ������ ���� ����
        //playoneshot�� ������ ������ ������̿��� ���ļ� ����
        
        //loop�� true�� ���
        //play�� ������ ���� ��� �� ������ ������ �ٽ� ����
        //playoneshot�� ���������� �ѹ��� �����ϴµ�
        //������� ������ �־ ����
        sfxSource.PlayOneShot(soundDictionary[type]);
    }

    /// <summary>
    /// BGM ��� �Լ�
    /// </summary>
    public void PlayBGM(BGMType type)
    {
        //���� bgmSource�� ������ ��� ������ ����Ϸ��� ��� ���ǰ� ������ Ȯ���ϴ� �ڵ�
        //�̹� ���� ������ ��� ���̶�� �ߺ��ؼ� ������� �ʵ��� ����
        if (bgmSource.clip == soundDictionary[type])
            return;
        //dictionary�� �ִ� bgmtype�̶� bgmsource.clip �̸��� ���ٸ�
        bgmSource.clip = soundDictionary[type];

        //��� ����ض�.
        bgmSource.Play();

        //�� �ڵ��� ������ ��� ������ �ߺ� ����� �����ϰ�,
        //��û�� ��� ������ �ٸ� ��쿡�� ���ο� ��� ������ �����ϰ� ���
    }

    public void SetVolume(string name, float volume)
    {
        if (name == "BGM")
        {
            bgmSource.volume = volume;
            PlayerPrefs.SetFloat("BGM", volume);
        }
        else if (name == "SFX")
        {
            sfxSource.volume = volume;
            PlayerPrefs.SetFloat("SFX", volume);
        }
    }

    /// <summary>
    /// Scene �ε� �� �ڵ����� BGM ȣ�����ִ� �Լ�
    /// </summary>
    public void OnLoadCompleted(Scene scene, LoadSceneMode loadSceneMode)
    {
        switch (scene.name)
        {
            case "Title":
                //bgmSource�� ����ְų� bgmsource�� enum BGMType�� Title�� �ٸ��ٸ�(�ٸ� �뷡�� ����ǰ� �ִٸ�)
                if (bgmSource.clip == null || bgmSource.clip != soundDictionary[BGMType.Title])
                {
                    //Title enumBGMType�� �ٲ��
                    bgmSource.clip = soundDictionary[BGMType.Title];
                    //�ݺ����
                    bgmSource.Play();
                }
                break;


            case "InGame":
                //���� ����
                if (bgmSource.clip == null || bgmSource.clip != soundDictionary[BGMType.InGame])
                {
                    bgmSource.clip = soundDictionary[BGMType.InGame];
                    bgmSource.Play();
                }
                break;
        }
    }
    /// <summary>
    /// SoundManager ���� �Լ�
    /// </summary>
    public void Init()
    {
        //���ο� �� ���ӿ�����Ʈ 2���� SFX�� BGM�̶�� �̸����� ����.
        GameObject sfxGameObject = new GameObject("SFX");
        GameObject bgmGameObject = new GameObject("BGM");

        //�� ���� ���ο� ���� ������Ʈ(sfxGameObject�� bgmGameObject)�� ������ ��,
        //�� �� ������Ʈ�� �θ� ���� SoundManager ��ü�� ����
        sfxGameObject.transform.SetParent(gameObject.transform);
        bgmGameObject.transform.SetParent(gameObject.transform);

        //�� ���� ������Ʈ�鿡 AudioSource ������Ʈ�� �޾���.
        sfxSource = sfxGameObject.AddComponent<AudioSource>();
        bgmSource = bgmGameObject.AddComponent<AudioSource>();

        //Resources ���� ���� Sounds������ SFX AudioClip�� ��� �ε�.
        var sfxClipArr = Resources.LoadAll<AudioClip>("Sounds/SFX");
        ClipLoader<SFXType>(sfxClipArr);

        //Resources ���� ���� Sounds������ BGM AudioClip�� ��� �ε�.
        var bgmClipArr = Resources.LoadAll<AudioClip>("Sounds/BGM");
        ClipLoader<BGMType>(bgmClipArr);


        //���� ������Ʈ�� Ȱ��ȭ�� �� ������� �ڵ����� ������� �ʰ���(False)
        bgmSource.playOnAwake = false;
        //�ݺ� ����Ұ��� ����(�⺻�� false)
        //loop�� false�� ��� play()�� �����ϸ� �ѹ��� ���.
        //true�� ��� �ݺ� ���.
        bgmSource.loop = true;
        //���� BGM ���� ����
        bgmSource.volume = 0.3f;

        //���� ������Ʈ�� Ȱ��ȭ�� �� ������� �ڵ����� ������� �ʰ���(False)
        sfxSource.playOnAwake = false;
        //���� SFX ���� ����
        sfxSource.volume = 1f;

        //BGM�� SFX�� �Ҹ��� �ִ� 1�� ����.
        bgmSource.volume = PlayerPrefs.GetFloat("BGM", 1);
        sfxSource.volume = PlayerPrefs.GetFloat("SFX", 1);

        //Scene�� ��ȯ�ǰ� load�� ���� �� Ÿ��Ʋ�� �̸��� ���� �ٸ� �뷡�� ����.
        SceneManagerEx.OnLoadCompleted(OnLoadCompleted);
    }

    /// <summary>
    /// Ŭ�� �о��ִ� �Լ�
    /// </summary>
    public void ClipLoader<T>(AudioClip[] arr) where T : Enum
    {
        for (int i = 0; i < arr.Length; i++)
        {
            //Enum.Parse �޼��尡 ���������� ���ܸ� �߻���Ű�� �޼����̱�
            //������ ���� ��ȯ�� �����ϸ� FormatException �Ǵ� ArgumentException��
            //������ ������, �̸� ó���ϱ� ���� try-catch�� ���
            try
            {
                T type = (T)Enum.Parse(typeof(T), arr[i].name);
                soundDictionary.Add(type, arr[i]);
            }
            //Enum.Parse�� ������ ���(��, arr[i].name�� Enum�� ���� ���� ���), ��� �α׸� ���
            catch
            {
                Debug.LogWarning("Need Enum : " + arr[i].name);
            }
        }
    }
}
