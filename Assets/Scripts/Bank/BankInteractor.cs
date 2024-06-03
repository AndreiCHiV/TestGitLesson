public class BankInteractor : Interactor
{
    private BankRepository _repository;

    public int Coins => _repository.Coins;
    public override void OnCreate()
    {
        base.OnCreate();
        _repository = Game.GetRepository<BankRepository>();
    }

    public override void Initialze()
    {
        Bank.Initialize(this);
    }

    public bool IsEnougthCoins(int value)
    {
        return Coins >= value;
    }

    public void AddCoins(object sender, int value)
    {
        _repository.Coins += value;
        _repository.Save();
    }

    public void Spend(object sender, int value)
    {
        _repository.Coins -= value;
        _repository.Save();
    }

}
