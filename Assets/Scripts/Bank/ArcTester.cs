using System.Collections;
using UnityEngine;

public class ArcTester : MonoBehaviour
{
    public static Scene scene;

    private void Start()
    {
        SceneConfigExample sceneConfig = new SceneConfigExample();
        scene = new Scene(sceneConfig);

        StartCoroutine(scene.InitializeRoutine());
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
