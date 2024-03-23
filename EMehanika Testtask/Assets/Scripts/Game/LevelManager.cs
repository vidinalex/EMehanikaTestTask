using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    private static LevelManager _default;
    public static LevelManager Default => _default;
    private void Awake()
    {
        _default = this;
    }
    #endregion

    [SerializeField]
    private Transform _scoreTransform;

    public Vector3 ScorePos { get { return _scoreTransform.position; } }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
