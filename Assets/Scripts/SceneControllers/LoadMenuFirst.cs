using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class LoadMenuFirst : MonoBehaviour
{
    static LoadMenuFirst()
    {
        string scenePath = "Assets/Scenes/MainMenu.unity";
        SceneAsset cenaInicial = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
        EditorSceneManager.playModeStartScene = cenaInicial;
    }
}