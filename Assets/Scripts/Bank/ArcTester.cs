using UnityEngine;

public class ArcTester : MonoBehaviour
{
    private BankRepository _bankRepository;
    private BankInteractor _bankInteractor;
    private Coins _coins;

    private void Start()
    {
        _coins = new Coins();

        _bankRepository = new BankRepository(_coins);
        _bankRepository.Initialize();

        _bankInteractor = new BankInteractor(_bankRepository);
        _bankInteractor.Initialze();

        Debug.Log($"Coins in bank = {_bankInteractor.Coins}");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _bankInteractor.AddCoins(this, 5);
            Debug.Log($"Coins added (5), {_bankInteractor.Coins}");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _bankInteractor.Spend(this, 10);
            Debug.Log($"Coins spend (10), {_bankInteractor.Coins}");
        }
    }

}
