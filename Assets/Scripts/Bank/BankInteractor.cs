public class BankInteractor : Interactor
{
    private BankRepository _repository;

    public BankInteractor(BankRepository repository)
    {
        _repository = repository;
    }

    public int Coins => _repository.Coints;

    public bool IsEnougthCoins(int value)
    {
        return Coins >= value;
    }

    public void AddCoins(object sender, int value)
    {

    }

}
