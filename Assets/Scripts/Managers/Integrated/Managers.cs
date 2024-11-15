using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Managers : MonoBehaviour
{
    private static Managers instance;


    public static UIManager UIManager { get { return instance.uiManager; } }
    public static SoundManager SoundManager { get { return instance.soundManager; } }


    //���� �ʵ忡 ���� �Ŵ��� �ν��Ͻ� �ۼ� �� ������ return �ۼ�
    //���� Init���� CreateManager�� �Ŵ��� ���� ���� �� ����
    private UIManager uiManager;
    private SoundManager soundManager;




    //����Ƽ ���� �ֱ⿡�� awake���� ���� �����ϱ� ���ؼ� ���.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    /// <summary>
    /// �Ŵ��� �ʱ�ȭ �Լ�(���� ���� �� �Ŵ��� ����)
    /// </summary>
    private static void Init()
    {
        Screen.SetResolution(1920, 1080, true);

        GameObject gameObject = new GameObject("Managers");
        instance = gameObject.AddComponent<Managers>();

        DontDestroyOnLoad(gameObject);

        instance.uiManager = CreateManager<UIManager>(gameObject.transform);
        instance.soundManager = CreateManager<SoundManager>(gameObject.transform);
    }



    /// <summary>
    /// Hierarchyâ�� Manager�� ������ִ� �Լ�
    /// </summary>
    private static T CreateManager<T>(Transform parent) where T : MonoBehaviour, IManager
    {
        GameObject gameObject = new GameObject(typeof(T).Name);
        T generic = gameObject.AddComponent<T>();
        gameObject.transform.parent = parent;

        generic.Init();

        return generic;
    }
}
