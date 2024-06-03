using UnityEngine;

public class PlayerInteractor : Interactor
{
    public PlayerGame player { get; private set; }

    public override void Initialze()
    {
        base.Initialze();

        var goPlayer = new GameObject("Player_1");
        player = goPlayer.AddComponent<PlayerGame>();
    }

}