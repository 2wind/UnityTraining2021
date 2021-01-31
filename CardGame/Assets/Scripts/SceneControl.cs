using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public static SceneControl current;

    public List<Scene> activeGameScenes;
    


    // Start is called before the first frame update
    void Awake()
    {
        current = this;
        activeGameScenes = new List<Scene>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }


    // destroy any remaining game scene and load.
    public IEnumerator LoadScene(string sceneName)
    {
        // change active scene to Manager
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Manager"));

        int sceneCount = SceneManager.sceneCount;
        if (sceneCount > 1)
        {
            // Multiple Scenes loaded (Including Manager)
            // destroy All scenes but Manager.
            activeGameScenes.ForEach((scene) => { SceneManager.UnloadSceneAsync(scene); });
            activeGameScenes.Clear();
        }
        // Now only Manager scene is loaded.
        yield return StartCoroutine(nameof(LoadSceenAdditive), sceneName);
    }

    // Load new scene additive without destroying currenly loaded scenes.
    public IEnumerator LoadSceenAdditive(string sceneName)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Manager"));

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            // do loading screen work
            yield return null;
        }

        // set active scene to loaded scene.
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Manager")
        {
            activeGameScenes.Add(scene);
        }
    }


    public static void Quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                  Application.Quit();
        #endif

    }
}
