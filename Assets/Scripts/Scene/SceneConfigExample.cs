using System;
using System.Collections.Generic;

public class SceneConfigExample : SceneConfig
{
    public override Dictionary<Type, Interactor> CreateAllIteractors()
    {
        Dictionary<Type, Interactor> iteractorsMap = new Dictionary<Type, Interactor>();
        CreateInteractor<BankInteractor>(iteractorsMap);

        return iteractorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        Dictionary<Type, Repository> repositoriesMap = new Dictionary<Type, Repository>();

        CreateRepository<BankRepository>(repositoriesMap);

        return repositoriesMap;
    }
}
