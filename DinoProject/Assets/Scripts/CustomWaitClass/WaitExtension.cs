using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public static class WaitExtension
{
    public static void Wait(this MonoBehaviour monoBehaviour, float delay, UnityAction action)
    {
        monoBehaviour.StartCoroutine(ExecuteAction(delay, action));
    }

    public static IEnumerator ExecuteAction(float delay, UnityAction action)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
        yield break;
    }

}
