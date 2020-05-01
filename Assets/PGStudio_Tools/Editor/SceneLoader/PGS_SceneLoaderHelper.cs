using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PowerGameStudio.UI
{

    public class PGS_SceneLoaderHelper : MonoBehaviour
    {
        public static void CreateLoadScene()
        {
            GameObject sceneLoader = AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/PGStudio_Tools/Art/Prefabs/Loading_Canvas.prefab");
            if (sceneLoader)
            {           
                GameObject createGroup = (GameObject)Instantiate(sceneLoader);
                createGroup.name = "Loading_Scene";
            }
            else
            {
                EditorUtility.DisplayDialog("UI tools warning", "Cannot find Loading_Canvas.prefab", "OK");
            }

            
        }
        public static void CreateUICore()
        {
            GameObject ui = AssetDatabase.LoadAssetAtPath<GameObject>(
               "Assets/PGStudio_Tools/Art/Prefabs/UI.prefab");
            if (ui)
            {
                GameObject createGroup = (GameObject)Instantiate(ui);
                createGroup.name = "UI";
            }
            else
            {
                EditorUtility.DisplayDialog("UI tools warning", "Cannot find Loading_Canvas.prefab", "OK");
            }

            GameObject test = AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/PGStudio_Tools/Art/Prefabs/Tests/Test.prefab");

            if (test)
            {
                GameObject createGroup = (GameObject)Instantiate(test);
                createGroup.name = "TEST";
            }
            else
            {
                EditorUtility.DisplayDialog("UI tools warning", "Cannot find Test.prefab", "OK");
            }
        }

    } 
}
