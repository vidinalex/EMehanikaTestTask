using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopElement : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Button _selfBtn;
    [SerializeField]
    private TMP_Text _costTextfield;
    [SerializeField]
    private GameObject[] states;

    public void SetState(int index)
    {
        switch (index)
        {
            case 0:
                _selfBtn.interactable = true;
                break;
            case 1:
                _selfBtn.interactable = false;
                break;
            case 2:
                states[0].SetActive(false);
                states[1].SetActive(true);
                _selfBtn.interactable = false;
                break;
        }
    }

    public void SetCost(int cost)
    {
        _costTextfield.text = cost.ToString();
    }
}
