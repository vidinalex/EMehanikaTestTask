using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    private static ScoreManager _default;
    public static ScoreManager Default => _default;
    private void Awake()
    {
        _default = this;
    }
    #endregion

    public System.Action OnScoreUpdate;

    [SerializeField]
    private TMP_Text[] _scoreTextfield;

    private int[] _finalScore = new int[2];

    public void AddScore(int index, int amount) //лерп не нужен тк по одному прибавляем
    {
        _finalScore[index] += amount;
        _scoreTextfield[index].text = _finalScore[index].ToString();

        OnScoreUpdate?.Invoke();
    }

    public int GetScore(int index)
    {
        return _finalScore[index];
    }

    [ContextMenu("Add 500")]
    private void CheatScore()
    {
        AddScore(0, 500);
        AddScore(1, 500);
    }
}
