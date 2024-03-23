using System;
using System.Collections;
using UnityEngine;

public class LoaderPlaceholder : MonoBehaviour
{
    public Action<bool> OnComplete;

    [SerializeField]
    private float _simDuration;

    private const string PREFS_FIRST_LAUNCH = "FirstLaunch";

    // симул€ци€ серой части (loading)
    private void Start()
    {
        if(PlayerPrefs.GetInt(PREFS_FIRST_LAUNCH, 0) != 0)
        {
            OnComplete?.Invoke(false);
            return;
        }

        StartCoroutine(CPlaceholderWait());
    }

    private IEnumerator CPlaceholderWait()
    {
        yield return new WaitForSeconds(_simDuration);
        PlayerPrefs.SetInt(PREFS_FIRST_LAUNCH, 1);
        OnComplete?.Invoke(true);
    }
}
