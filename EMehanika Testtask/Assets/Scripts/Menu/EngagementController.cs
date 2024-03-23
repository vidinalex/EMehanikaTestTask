using UnityEngine;

public class EngagementController : MonoBehaviour
{
    [SerializeField]
    private MMenuManager _menuManager;
    [SerializeField]
    private GameObject[] stages;

    private int _currStageIndex;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currStageIndex++;
            if (_currStageIndex == stages.Length)
            {
                _menuManager.ShowMenu(false);
                gameObject.SetActive(false);
            }
            else
            {
                stages[_currStageIndex - 1].SetActive(false);
                stages[_currStageIndex].SetActive(true);
            }
        }
    }
}
