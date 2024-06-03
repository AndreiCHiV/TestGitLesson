using System;
using System.Collections.Generic;

public class SceneConfigExample : SceneConfig
{
    public const string SCENE_NAME = "L18";

    public override string SceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllIteractors()
    {
        Dictionary<Type, Interactor> interactorsMap = new Dictionary<Type, Interactor>();
        CreateInteractor<BankInteractor>(interactorsMap);
        CreateInteractor<PlayerInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        Dictionary<Type, Repository> repositoriesMap = new Dictionary<Type, Repository>();

        CreateRepository<BankRepository>(repositoriesMap);

        return repositoriesMap;
    }
}
