public static class Bank
{
    private static BankInteractor _bankInteractor;

    public static int Coins => _bankInteractor.Coins;
    public static bool IsInitialized { get; private set; }

    public static void Initialize(BankInteractor interactor)
    {
        _bankInteractor = interactor;
    }

    public static bool IsEnougthCoins(int value)
    {
        return _bankInteractor.IsEnougthCoins(value);
    }

    public static void AddCoins(object sender, int value)
    {
        _bankInteractor.AddCoins(sender, value);
    }

    public static void Spend(object sender, int value)
    {
        _bankInteractor.Spend(sender, value);
    }
}
