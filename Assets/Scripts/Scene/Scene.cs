using System;
using System.Collections;

public class Scene
{
    private InteractorsBase _interactorsBase;
    private RepositoriesBase _repositoriesBase;

    private SceneConfig _sceneConfig;

    public Scene(SceneConfig config)
    {
        _sceneConfig = config;
        _interactorsBase = new InteractorsBase(config);
        _repositoriesBase = new RepositoriesBase(config);

    }

    public T GetRepository<T>() where T : Repository
    {
        return _repositoriesBase.GetRepository<T>();
    }

    public T GetIteractor<T>() where T : Interactor
    {
        return _interactorsBase.GetInteractor<T>();
    }

    public IEnumerator InitializeRoutine()
    {
        _interactorsBase.CreateAllInteractor();
        _repositoriesBase.CreateAllRepository();

        yield return null;

        _interactorsBase.SendOnCreateToAllInteractors();
        _repositoriesBase.SendOnCreateToAllRepository();

        yield return null;

        _interactorsBase.InitializeAllInteractors();
        _repositoriesBase.InitializeAllRepository();

        yield return null;

        _interactorsBase.SendOnStartToAllInteractors();
        _repositoriesBase.SendOnStartToAllRepository();
    }

}
