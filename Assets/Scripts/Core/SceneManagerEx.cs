using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

    public static class SceneManagerEx
    {
        private static readonly Dictionary<SceneType, string> typeToStringDic = new Dictionary<SceneType, string>();   //��Ÿ�� string ��ȯ ������ ���� Dictionary

        /// <summary>
        /// �� �ε� �Լ�
        /// </summary>
        public static void LoadScene(SceneType type)
        {
            SceneManager.LoadScene(GetSceneName(type));
        }

        /// <summary>
        /// �� �̸� ��ȯ���ִ� �Լ�
        /// </summary>
        private static string GetSceneName(SceneType type)
        {
            if (!typeToStringDic.TryGetValue(type, out string name))
            {
                name = type.ToString();
                typeToStringDic[type] = name;
            }

            return name;
        }

        /// <summary>
        /// �� �ε���� �� ȣ���� action ���̴� �Լ�
        /// </summary>
        public static void OnLoadCompleted(UnityAction<UnityEngine.SceneManagement.Scene, LoadSceneMode> callback)
        {
            SceneManager.sceneLoaded += callback;
        }
    }

