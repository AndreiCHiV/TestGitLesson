using System;
using System.Collections.Generic;

public abstract class SceneConfig
{
    public abstract Repository[] CreateAllRepositories();
    public abstract Interactor[] CreateAllIteractors();

    public void CreateInteractor<T>(Dictionary<Type, Interactor> interactorMap) where T : Interactor, new()
    {
        var interactor = new T();
        var type = typeof(T);

        interactorMap[type] = interactor;
    }

    public void CreateRepository<T>(Dictionary<Type, Repository> repositoryMap) where T : Repository, new()
    {
        var repository = new T();
        var type = typeof(T);

        repositoryMap[type] = repository;
    }

}
