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





    //Dictionary key���� Enum�� CreateDictionary �޼����� ���ʸ� �Ű������� ���� ��.
    //CreateDictionary �Ű������� Resources ���� ���� ���ڿ� ��θ� ����.

    /// <summary>
    /// UIDictionary�� �� �־��ִ� �Լ�
    /// </summary>
    private void CreateDictionary<T>(string path) where T : Enum
    {
        //�Է¹��� Enum Ÿ�� T�� ��� ���� ��ȸ�ϸ�(���� UIType��� Enum�ȿ� ���� 3���� �ִٸ� 3��),
        //�� ���� type ������ �Ҵ�.

        //�ݺ����� ���鼭 type�� ��°��� Enum���� ���� ������ŭ �޶���.
        //���� ��� UIType�� 1,2,3�� ������
        //1. ù��° �ݺ� �� type ���� = 1, 2��° �ݺ��� = 2, 3��° �ݺ��� = 3 �̷���.
        foreach (T type in Enum.GetValues(typeof(T)))
        {
            GameObject gameObject = Resources.Load<GameObject>(string.Format($"{path}/{type.ToString()}"));

            //gameobject�� null�϶� �ؿ� UIDictionary.Add(type, gameObject);�� ���� ���ϰ� �ǳ� ��.
            if (gameObject == null)
                continue;

            //�Է¹��� Enum���� ���� ������ŭ UIDictionary�� key���� type, value���� gameObject�� �Ҵ�.
            UIDictionary.Add(type, gameObject);
        }
    }






    /// <summary>
    /// Scene�� �⺻ UI����ִ� �Լ�
    /// </summary>
    public void SetBaseUI(Scene scene, LoadSceneMode mode)
    {
        depth.Clear();

        //sceneType ������ ����Ƽ Scene�� �̸�(���ڿ�)�� Enum������ ��ȯ�Ͽ�
        //���� �� CreateUI �޼��带 �̿��Ͽ� �������� �������.

        //�� Init�޼��忡�� Scene�� �ٲ� �� Load�� �� �Ǹ� SetBaseUI �޼��带
        //�����Ͽ� �ε�� Scene �̸��� SceneType���� Enum���� ������
        //�ش� enum�� �ش��ϴ� �������� CreateUI�� ���� ����.
        SceneType sceneType = StringExtensions.StringToEnum<SceneType>(scene.name);
        CreateUI(sceneType);
    }




    //UI�� ������ִ� �޼���. ���� curPopupActive�� SetActive ���.
    //true = SetActive.true
    public BasePopup CreateUI(Enum type, bool curPopupActive = true)
    {
        //UIDictionary�� �ش� key���� Enum���� ���� ��� LogWarning ���.
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
