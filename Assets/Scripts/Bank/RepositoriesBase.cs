using System;
using System.Collections.Generic;

public class RepositoriesBase
{
    private Dictionary<Type, Repository> _repositoriesMap;
    private SceneConfig _sceneConfig;

    public RepositoriesBase(SceneConfig config)
    {
        _sceneConfig = config;
    }

    public void CreateAllRepository()
    {
        _repositoriesMap = _sceneConfig.CreateAllRepositories();
    }

    private void CreateRepository<T>() where T : Repository, new()
    {
        var repository = new T();
        var type = typeof(T);

        _repositoriesMap[type] = repository;
    }

    public void SendOnCreateToAllRepository()
    {
        var allInteractors = _repositoriesMap.Values;

        foreach (var interactor in allInteractors)
        {
            interactor.OnCreate();
        }
    }

    public void InitializeAllRepository()
    {
        var allInteractors = _repositoriesMap.Values;

        foreach (var interactor in allInteractors)
        {
            interactor.Initialize();
        }
    }

    public void SendOnStartToAllRepository()
    {
        var allInteractors = _repositoriesMap.Values;

        foreach (var interactor in allInteractors)
        {
            interactor.OnStart();
        }
    }

    public T GetRepository<T>() where T : Repository
    {
        var type = typeof(T);
        return (T)_repositoriesMap[type];
    }
}
