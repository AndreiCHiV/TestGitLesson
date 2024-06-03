using System.Collections;
using UnityEngine;

public sealed class Coroutines : MonoBehaviour
{
    private static Coroutines instance
    {
        get
        {
            if (_mInstance == null)
            {
                var go = new GameObject("[COROUTINE MANAGER]");
                _mInstance = go.AddComponent<Coroutines>();
                DontDestroyOnLoad(go);
            }
            return _mInstance;
        }
    }

    private static Coroutines _mInstance;

    public static Coroutine StartRoutine(IEnumerator enumerator)
    {
        return instance.StartCoroutine(enumerator);
    }

    public static void StopRoutine(Coroutine routine)
    {
        if (routine != null)
        {
            instance.StopCoroutine(routine);
        }
    }

}
