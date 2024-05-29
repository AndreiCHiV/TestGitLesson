public class BankInteractor : Interactor
{
    private BankRepository _repository;

    public BankInteractor()
    {
        //_repository = repository;
    }

    public int Coins => _repository.Coints;

    public bool IsEnougthCoins(int value)
    {
        return Coins >= value;
    }

    public void AddCoins(object sender, int value)
    {
        _repository.Coints += value;
        _repository.Save();
    }

    public void Spend(object sender, int value)
    {
        _repository.Coints -= value;
        _repository.Save();
    }

}
