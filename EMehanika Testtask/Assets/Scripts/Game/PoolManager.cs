using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region Singleton
    private static PoolManager _default;
    public static PoolManager Default => _default;
    private void Awake()
    {
        _default = this;
    }
    #endregion

    [SerializeField]
    private int _maxElements;
    [SerializeField]
    private GameObject[] _instances;
    [SerializeField]
    private Transform _canvasPoolRef;

    private List<Pool> _pool = new List<Pool>();

    private const float MAX_DELAY = 0.5f;

    public struct Pool
    {
        public Queue<GameObject> objects;
    }

    private void Start()
    {
        for (int i = 0; i < _instances.Length; i++)
        {
            _pool.Add(new Pool { objects = new Queue<GameObject>() });
            for (int j = 0; j < _maxElements; j++)
            {
                GameObject tempGO = Instantiate(_instances[i], _canvasPoolRef.transform);
                tempGO.SetActive(false);
                _pool[i].objects.Enqueue(tempGO);
            }
        }
    }

    public void Instantiate(int poolIndex, Vector3 originPos, bool isDelayed)
    {
        GameObject tempGO = _pool[poolIndex].objects.Dequeue();
        tempGO.transform.position = originPos;

        StartCoroutine(CWaitAndEnable(tempGO, isDelayed ? MAX_DELAY : 0));
        _pool[poolIndex].objects.Enqueue(tempGO);
    }

    private IEnumerator CWaitAndEnable(GameObject tempGO, float delay)
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0,delay));
        tempGO.SetActive(true);
    }
}
