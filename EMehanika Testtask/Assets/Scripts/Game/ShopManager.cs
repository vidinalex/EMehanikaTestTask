using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [System.Serializable]
    public struct BuyingElements
    {
        public GameObject[] element;
    }

    [System.Serializable]
    public struct CostsMatrix
    {
        public int[] cost;
    }

    private enum StateName
    {
        Able,
        Unable,
        Maxed
    }

    [SerializeField]
    private ScoreManager _scoreManager;
    [SerializeField]
    private BuyingElements[] _buyingElements;
    [SerializeField]
    private CostsMatrix[] _costMatrixs;
    [SerializeField]
    private ShopElement[] _shopButtonElements;

    private int[] _currBoughtStatus = new int[3] {0,0,0};

    private void OnEnable()
    {
        _scoreManager.OnScoreUpdate += UpdatePurchasePower;
    }

    private void OnDisable()
    {
        _scoreManager.OnScoreUpdate -= UpdatePurchasePower;
    }

    private void Start()
    {
        UpdatePurchasePower();
        UpdateCosts();
    }

    private void UpdatePurchasePower()
    {
        for (int i = 0; i < _shopButtonElements.Length; i++)
        {
            if (_currBoughtStatus[i] == _buyingElements[i].element.Length)
            {
                _shopButtonElements[i].SetState((int) StateName.Maxed);
                continue;
            }

            if (_costMatrixs[i].cost[_currBoughtStatus[i]] <= _scoreManager.GetScore(i == 1? 0 : 1))
            {
                _shopButtonElements[i].SetState((int)StateName.Able);
            }
            else
            {
                _shopButtonElements[i].SetState((int)StateName.Unable);
            }
        }
    }

    private void UpdateCosts()
    {
        for (int i = 0; i < _shopButtonElements.Length; i++)
        {
            if (_currBoughtStatus[i] == _buyingElements[i].element.Length)
            {
                return;
            }
            _shopButtonElements[i].SetCost(_costMatrixs[i].cost[_currBoughtStatus[i]]);
        }
    }

    public void ProceedBuy(int index)
    {
        _scoreManager.AddScore((index == 1 ? 0 : 1), -_costMatrixs[index].cost[_currBoughtStatus[index]]);
        _currBoughtStatus[index]++;
        _buyingElements[index].element[_currBoughtStatus[index] - 1].SetActive(true);

        UpdatePurchasePower();
        UpdateCosts();
    }
}
