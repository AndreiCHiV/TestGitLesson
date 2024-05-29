using System;
using System.Collections.Generic;

public class RepositoriesBase
{
    private Dictionary<Type, Repository> _repositoriesMap;

    public RepositoriesBase()
    {
        _repositoriesMap = new Dictionary<Type, Repository>();
    }

    public void CreateAllRepository()
    {
        //CreateRepository<BankRepository>();
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
            interactor.Initialze();
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

    public T GetInteractor<T>() where T : Interactor
    {
        var type = typeof(T);
        return (T)_repositoriesMap[type];
    }
}
