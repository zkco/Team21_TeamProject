using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Managers : MonoBehaviour
{
    private static Managers instance;


    public static UIManager UIManager { get { return instance.uiManager; } }
    public static SoundManager SoundManager { get { return instance.soundManager; } }

    public static PlayerManager PlayerManager { get { return instance.playerManager; } }

    public static DataManager DataManager { get { return instance.dataManager; } }
    public static QuestManager QuestManager { get { return instance.questManager; } }
    //���� �ʵ忡 ���� �Ŵ��� �ν��Ͻ� �ۼ� �� ������ return �ۼ�
    //���� Init���� CreateManager�� �Ŵ��� ���� ���� �� ����
    private UIManager uiManager;
    private SoundManager soundManager;
    private PlayerManager playerManager;
    private DataManager dataManager;
    private QuestManager questManager;



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
        instance.playerManager = CreateManager<PlayerManager>(gameObject.transform);
        instance.dataManager = CreateManager<DataManager>(gameObject.transform);
        instance.questManager = CreateManager<QuestManager>(gameObject.transform);
    }



    /// <summary>
    /// Hierarchyâ�� Manager�� ������ִ� �Լ�
    /// </summary>
    private static T CreateManager<T>(Transform parent) where T : MonoBehaviour, IManager
    {
        GameObject gameObject = new GameObject(typeof(T).Name);
        T generic = gameObject.AddComponent<T>();
        gameObject.transform.parent = parent;

        //�� �ڵ带 ���� �Ŵ����� ó�� ������� �� Init�� ���������.
        generic.Init();

        return generic;
    }
}
