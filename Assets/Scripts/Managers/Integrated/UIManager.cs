using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour,IManager
{
    private readonly Dictionary<Enum, GameObject> UIDictionary = new Dictionary<Enum, GameObject>();
    private readonly Stack<BasePopup> depth = new Stack<BasePopup>();
    public void Init()
    {
        CreateDictionary<SceneType>("Prefabs/UI/Scenes");
        CreateDictionary<UIType>("Prefabs/UI/Popup");

        SceneManagerEx.OnLoadCompleted(SetBaseUI);
    }





    //Dictionary key값인 Enum이 CreateDictionary 메서드의 제너릭 매개변수로 들어가야 함.
    //CreateDictionary 매개변수는 Resources 폴더 안의 문자열 경로를 받음.

    /// <summary>
    /// UIDictionary에 값 넣어주는 함수
    /// </summary>
    private void CreateDictionary<T>(string path) where T : Enum
    {
        //입력받은 Enum 타입 T의 모든 값을 순회하며(만약 UIType라는 Enum안에 값이 3개가 있다면 3번),
        //각 값을 type 변수에 할당.

        //반복문이 돌면서 type의 출력값은 Enum안의 값의 개수만큼 달라짐.
        //예를 들어 UIType에 1,2,3이 있으면
        //1. 첫번째 반복 때 type 변수 = 1, 2번째 반복때 = 2, 3번째 반복때 = 3 이런식.
        foreach (T type in Enum.GetValues(typeof(T)))
        {
            GameObject gameObject = Resources.Load<GameObject>(string.Format($"{path}/{type.ToString()}"));

            //gameobject가 null일때 밑에 UIDictionary.Add(type, gameObject);를 실행 안하고 건너 뜀.
            if (gameObject == null)
                continue;

            //입력받은 Enum안의 값의 개수만큼 UIDictionary의 key값에 type, value값에 gameObject를 할당.
            UIDictionary.Add(type, gameObject);
        }
    }






    /// <summary>
    /// Scene에 기본 UI깔아주는 함수
    /// </summary>
    public void SetBaseUI(Scene scene, LoadSceneMode mode)
    {
        depth.Clear();

        //sceneType 변수에 유니티 Scene의 이름(문자열)을 Enum형으로 변환하여
        //저장 후 CreateUI 메서드를 이용하여 프리팹을 만들어줌.

        //위 Init메서드에서 Scene이 바뀔 때 Load가 다 되면 SetBaseUI 메서드를
        //실행하여 로드된 Scene 이름과 SceneType안의 Enum값과 같으면
        //해당 enum에 해당하는 프리팹을 CreateUI를 통해 생성.
        SceneType sceneType = StringExtensions.StringToEnum<SceneType>(scene.name);
        CreateUI(sceneType);
    }




    //UI를 만들어주는 메서드. 뒤의 curPopupActive는 SetActive 기능.
    //true = SetActive.true
    public BasePopup CreateUI(Enum type, bool curPopupActive = true)
    {
        //UIDictionary에 해당 key값인 Enum값이 없을 경우 LogWarning 띄움.
        if (!UIDictionary.TryGetValue(type, out GameObject prefab))
        {
            Debug.LogWarning($"Is Not Scene base UI : {type}");
            return null;
        }

        GameObject clone = Instantiate(prefab);

        if (depth.TryPeek(out BasePopup beforeUI) && curPopupActive)
        {
            beforeUI.gameObject.SetActive(false);
        }

        BasePopup afterUI = clone.GetComponent<BasePopup>();
        afterUI.Init();

        depth.Push(afterUI);

        return afterUI;
    }

    public void CloseUI(Action LoadScene = null)
    {
        if (LoadScene != null)
        {
            depth.Clear();
            LoadScene();
            return;
        }

        if (depth.Count == 1)
        {
            return;
        }

        Destroy(depth.Pop().gameObject);

        if (depth.TryPeek(out BasePopup baseUI))
        {
            baseUI.gameObject.SetActive(true);
        }
    }

}
