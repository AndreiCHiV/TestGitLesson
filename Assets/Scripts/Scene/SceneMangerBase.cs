using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneMangerBase
{
    public event Action<Scene> OnSceneLoadedEvent;

    public Scene Scene { get; private set; }


    public bool isLoading { get; private set; }

    protected Dictionary<string, SceneConfig> _sceneConfigMap;

    public SceneMangerBase()
    {
        _sceneConfigMap = new Dictionary<string, SceneConfig>();
    }

    public abstract void InitScenesMap();

    public T GetRepository<T>() where T : Repository
    {
        return Scene.GetRepository<T>();
    }

    public T GetInteractor<T>() where T : Interactor
    {
        return Scene.GetIteractor<T>();
    }

    public Coroutine LoadCurrentSceneAsync()
    {
        if (isLoading)
        {
            throw new Exception("Scene is loading now!");
        }

        var sceneName = SceneManager.GetActiveScene().name;
        var config = _sceneConfigMap[sceneName];
        return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));
    }

    private IEnumerator LoadCurrentSceneRoutine(SceneConfig sceneConfig)
    {
        isLoading = true;

        yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));

        isLoading = false;
        OnSceneLoadedEvent?.Invoke(Scene);
    }

    public Coroutine LoadNewSceneAsync(string sceneName)
    {
        if (isLoading)
        {
            throw new Exception("Scene is loading now!");
        }

        var config = _sceneConfigMap[sceneName];
        return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
    }

    private IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
    {
        isLoading = true;

        yield return Coroutines.StartRoutine(LoadSceneRoutine(sceneConfig));
        yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));

        isLoading = false;
        OnSceneLoadedEvent?.Invoke(Scene);
    }

    private IEnumerator LoadSceneRoutine(SceneConfig sceneConfig)
    {
        var async = SceneManager.LoadSceneAsync(sceneConfig.SceneName);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
        {
            yield return null;
        }

        async.allowSceneActivation = true;
    }

    private IEnumerator InitializeSceneRoutine(SceneConfig sceneConfig)
    {
        Scene = new Scene(sceneConfig);
        yield return Scene.InitializeAsync();
    }
}