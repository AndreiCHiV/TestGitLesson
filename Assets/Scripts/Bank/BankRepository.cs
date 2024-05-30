using UnityEngine;

public class BankRepository : Repository
{
    private int _coins;
    public const string KEY = "BANK_KEY";

    public int Coins
    {
        get => _coins;
        set => _coins = value;
    }
    public override void Initialize()
    {
        Coins = PlayerPrefs.GetInt(KEY, 0);
    }

    public override void Save()
    {
        PlayerPrefs.SetInt(KEY, Coins);
    }
}
