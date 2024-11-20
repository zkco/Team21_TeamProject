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
    //여기 필드에 만들 매니저 인스턴스 작성 후 위에서 return 작성
    //이후 Init에서 CreateManager로 매니저 게임 실행 시 생성
    private UIManager uiManager;
    private SoundManager soundManager;
    private PlayerManager playerManager;
    private DataManager dataManager;
    private QuestManager questManager;



    //유니티 생명 주기에서 awake보다 먼저 실행하기 위해서 사용.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    /// <summary>
    /// 매니저 초기화 함수(게임 실행 전 매니저 생성)
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
    /// Hierarchy창에 Manager들 만들어주는 함수
    /// </summary>
    private static T CreateManager<T>(Transform parent) where T : MonoBehaviour, IManager
    {
        GameObject gameObject = new GameObject(typeof(T).Name);
        T generic = gameObject.AddComponent<T>();
        gameObject.transform.parent = parent;

        //이 코드를 통해 매니저가 처음 만들어질 때 Init을 실행시켜줌.
        generic.Init();

        return generic;
    }
}
