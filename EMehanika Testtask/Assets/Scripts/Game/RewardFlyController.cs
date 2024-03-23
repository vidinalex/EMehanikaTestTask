using System.Collections;
using UnityEngine;

public class RewardFlyController : MonoBehaviour
{
    [SerializeField]
    private float _flyDuration = 1.0f;
    [SerializeField]
    private int _rewardIndex, _rewardAmount;

    private Vector3 _initialPos;
    private Coroutine _flyCoroutine;

    private void OnEnable()
    {
        _initialPos = transform.position;
        StartCoroutine(CFlyTowardsScore());
    }

    private void OnDisable()
    {
        if (_flyCoroutine != null)
        {
            StopCoroutine(_flyCoroutine);
        }
    }

    private IEnumerator CFlyTowardsScore()
    {
        float timeElapsed = 0;

        while (timeElapsed < _flyDuration)
        {
            transform.position = Vector3.Lerp(_initialPos, LevelManager.Default.ScorePos, timeElapsed / _flyDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        ScoreManager.Default.AddScore(_rewardIndex, _rewardAmount);
        gameObject.SetActive(false);
    }
}
