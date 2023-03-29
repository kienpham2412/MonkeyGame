using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAfterDelay : MonoBehaviour
{
    public float delay;
    private object delayRoutine;

    private void Awake()
    {
        delayRoutine = new WaitForSeconds(delay);
    }

    private IEnumerator DelayHideRoutine()
    {
        yield return delayRoutine;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(DelayHideRoutine());
    }
}
