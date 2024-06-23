using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class StartSceneLoader
{
    // Name of the Start Scene
    private const string startSceneName = "Start";
    private static bool isSwitchingScene;

    // Static constructor to subscribe to the playModeStateChanged event
    static StartSceneLoader()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        // Check if about to enter Play mode
        if (state == PlayModeStateChange.ExitingEditMode && !isSwitchingScene)
        {
            // Check if the current active scene is not the start scene
            if (SceneManager.GetActiveScene().name != startSceneName)
            {
                isSwitchingScene = true;
                // Save the current scene and load the start scene
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    EditorSceneManager.OpenScene("Assets/Scenes/" + startSceneName + ".unity");
                }
                EditorApplication.isPlaying = false;
                isSwitchingScene = false;
            }
        }

        // After opening the start scene, automatically enter Play mode
        if (state == PlayModeStateChange.EnteredEditMode && isSwitchingScene)
        {
            EditorApplication.isPlaying = true;
        }
    }
}
