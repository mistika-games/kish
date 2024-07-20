using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    public class ScenesSwitcher
    {
        [MenuItem("Scenes/Start", false, 0)]
        public static void OpenStartScene()
        {
            var scene = OpenScene("Assets/Game/Scenes/start.unity");
            //SelectGameObject(scene, "GameController");
        }
        
        [MenuItem("Scenes/level_1", false, 1)]
        public static void OpenBattleScene()
        {
            OpenScene("Assets/Game/Scenes/level_1.unity");
        }

        [MenuItem("Select/Character")]
        public static void SelectCharacter()
        {
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/Game/Prefabs/Character.prefab");
        }

        private static Scene OpenScene(string scenePath, OpenSceneMode openSceneMode = OpenSceneMode.Single)
        {
            return EditorSceneManager.OpenScene(scenePath, openSceneMode);
        }

        private static void SelectGameObject(Scene scene, string targetGameObjectName)
        {
            var rootGameObjects = scene.GetRootGameObjects();
            
            foreach (var go in rootGameObjects)
            {
                if (go.name == targetGameObjectName)
                {
                    Selection.activeObject = go;
                    return;
                }
            }

            Debug.Log($"{targetGameObjectName} not found");
        }
    }
}