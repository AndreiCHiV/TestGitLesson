using System.Collections;
using UnityEngine;

public class Tester
{
    private Coroutine _routine;

    public void StartTestRoutine()
    {
        if (_routine != null)
        {
            return;
        }
        _routine = Coroutines.StartRoutine(LifeRoutine());
    }

    public void StopTestRoutine()
    {
        Coroutines.StopRoutine(_routine);
        _routine = null;
    }

    private IEnumerator LifeRoutine()
    {
        var timer = 0f;

        while (true)
        {
            Debug.Log($"LifeRoutine: {timer}");
            yield return new WaitForSeconds(1f);
            timer++;
        }
    }

}