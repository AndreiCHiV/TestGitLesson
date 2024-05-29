using System;
using System.Collections.Generic;

public class InteractorsBase
{
    private Dictionary<Type, Interactor> _interactrosMap;

    public InteractorsBase()
    {
        _interactrosMap = new Dictionary<Type, Interactor>();
    }

    public void CreateAllInteractor()
    {
        CreateInteractor<BankInteractor>();
    }

    private void CreateInteractor<T>() where T : Interactor, new()
    {
        var interactor = new T();
        var type = typeof(T);

        _interactrosMap[type] = interactor;
    }

    public void SendOnCreateToAllInteractors()
    {
        var allInteractors = _interactrosMap.Values;

        foreach (var interactor in allInteractors)
        {
            interactor.OnCreate();
        }
    }

    public void InitializeAllInteractors()
    {
        var allInteractors = _interactrosMap.Values;

        foreach (var interactor in allInteractors)
        {
            interactor.Initialze();
        }
    }

    public void SendOnStartToAllInteractors()
    {
        var allInteractors = _interactrosMap.Values;

        foreach (var interactor in allInteractors)
        {
            interactor.OnStart();
        }
    }

    public T GetInteractor<T>() where T : Interactor
    {
        var type = typeof(T);
        return (T)_interactrosMap[type];
    }
}
