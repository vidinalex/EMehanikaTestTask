using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInputManager : MonoBehaviour
{
    #region Singleton
    private static LevelInputManager _default;
    public static LevelInputManager Default => _default;
    private void Awake()
    {
        _default = this;
    }
    #endregion

    [SerializeField]
    private float _touchSpeedMod;
    [SerializeField]
    private float _speedDuration;

    private Coroutine _currDurationCountCour;
    private bool isBoosted = false;

    public float GetCurrentSpeedMod()
    {
        return 1 + _touchSpeedMod * (isBoosted? 1 : 0);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_currDurationCountCour != null)
            {
                StopCoroutine(_currDurationCountCour);
            }

            _currDurationCountCour = StartCoroutine(CSpeedDurationCount());
        }
    }

    private IEnumerator CSpeedDurationCount()
    {
        isBoosted = true;
        yield return new WaitForSeconds(_speedDuration);
        isBoosted = false;
    }
}
