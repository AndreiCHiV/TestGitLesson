using System.Collections;
using UnityEngine.SceneManagement;

public class SceneMangerBase
{
    public Scene Scene { get; private set; }

    private IEnumerator LoadSceneAsync(SceneConfig sceneConfig)
    {
        var async = SceneManager.LoadSceneAsync(sceneConfig.SceneName);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
        {
            yield return null;
        }

        async.allowSceneActivation = true;
    }

    private IEnumerator InitializeSceneAsync(SceneConfig sceneConfig)
    {
        Scene = new Scene(sceneConfig);
        yield return Scene.InitializeAsync();
    }
}