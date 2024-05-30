using System.Collections;
using UnityEngine;

public class ArcTester : MonoBehaviour
{
    public static InteractorsBase interactorsBase;
    public static RepositoriesBase repositoriesBase;

    private void Start()
    {
        StartCoroutine(StartGameRotine());
    }


    private void Update()
    {
        if (!Bank.IsInitialized)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Bank.AddCoins(this, 5);
            Debug.Log($"Coins added (5), {Bank.Coins}");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Bank.Spend(this, 10);
            Debug.Log($"Coins spend (10), {Bank.Coins}");
        }
    }

    private IEnumerator StartGameRotine()
    {
        interactorsBase = new InteractorsBase();
        repositoriesBase = new RepositoriesBase();

        interactorsBase.CreateAllInteractor();
        repositoriesBase.CreateAllRepository();

        yield return null;

        interactorsBase.SendOnCreateToAllInteractors();
        repositoriesBase.SendOnCreateToAllRepository();

        yield return null;

        interactorsBase.InitializeAllInteractors();
        repositoriesBase.InitializeAllRepository();

        yield return null;

        interactorsBase.SendOnStartToAllInteractors();
        repositoriesBase.SendOnStartToAllRepository();

        yield return null;

    }

}
