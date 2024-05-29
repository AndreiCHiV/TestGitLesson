using UnityEngine;

public class BankRepository : Repository
{
    private readonly Coins _coins;

    public BankRepository(Coins coins)
    {
        _coins = coins;
    }
    public int Coints
    {
        get => _coins.coint;
        set => _coins.coint = value;
    }
    public override void Initialize()
    {
        Coints = PlayerPrefs.GetInt(Coins.KEY, 0);
    }

    public override void Save()
    {
        PlayerPrefs.SetInt(Coins.KEY, Coints);
    }
}
