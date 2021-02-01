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

    public IEnumerator UnloadLastScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Manager"));

        int sceneCount = SceneManager.sceneCount;
        if (sceneCount > 1)
        {
            // Multiple Scenes loaded (Including Manager)
            // destroy last scene and move focus to next last scene.
            SceneManager.UnloadSceneAsync(activeGameScenes[sceneCount - 1]);
            activeGameScenes.RemoveAt(sceneCount - 1);
        }
        yield return null;

    }

    public IEnumerator UnloadAllScene()
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
        yield return null;
    }


    // destroy any remaining game scene and load.
    public IEnumerator LoadScene(string sceneName)
    {

        yield return StartCoroutine(nameof(UnloadAllScene));
        // Now only Manager scene is loaded.
        yield return StartCoroutine(nameof(LoadSceenAdditive), sceneName);
    }

    // Load new scene additive without destroying currenly loaded scenes.
    public IEnumerator LoadSceenAdditive(string sceneName)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Manager"));

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
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


    public void Quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                  Application.Quit();
        #endif

    }
}
