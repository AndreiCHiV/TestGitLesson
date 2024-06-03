using System.Collections;
using UnityEngine;

public class ArcTester : MonoBehaviour
{
    public static SceneMangerBase sceneManager;

    private void Start()
    {
        sceneManager = new SceneManagerExample();
        sceneManager.InitScenesMap();
        sceneManager.LoadCurrentSceneAsync();

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
}
