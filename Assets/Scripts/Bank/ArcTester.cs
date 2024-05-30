using System.Collections;
using UnityEngine;

public class ArcTester : MonoBehaviour
{
    private BankRepository _bankRepository;
    private BankInteractor _bankInteractor;

    public static InteractorsBase interactorsBase;
    public static RepositoriesBase repositoriesBase;

    private void Start()
    {
        _bankRepository = new BankRepository();
        _bankRepository.Initialize();

        _bankInteractor = new BankInteractor();
        _bankInteractor.Initialze();

        Debug.Log($"Coins in bank = {_bankInteractor.Coins}");

        StartCoroutine(StartGameRotine());
    }


    private void Update()
    {
        if ()
        {

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
