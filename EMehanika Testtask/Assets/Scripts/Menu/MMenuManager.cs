using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMenuManager : MonoBehaviour
{
    [SerializeField]
    private LoaderPlaceholder _loader;
    [SerializeField]
    private GameObject[] _stagesPool;
    [SerializeField]
    private GameObject _engagementStage;

    private Stack<GameObject> _stagesStack = new Stack<GameObject>();

    private void OnEnable()
    {
        _loader.OnComplete += ShowMenu;
    }

    private void OnDisable()
    {
        _loader.OnComplete -= ShowMenu;
    }

    public void ShowMenu(bool isEngagement)
    {
        _stagesPool[0].SetActive(false);

        if (isEngagement)
        {
            _engagementStage.SetActive(true);
        }
        else
        {
            _stagesPool[1].SetActive(true);
        }
    }

    private void Start()
    {
        _stagesStack.Push(_stagesPool[1]);
    }

    public void GoToStage(int index)
    {
        _stagesStack.Peek().SetActive(false);
        _stagesStack.Push(_stagesPool[index]);
        _stagesStack.Peek().SetActive(true);
    }

    public void GoToBack()
    {
        _stagesStack.Pop().SetActive(false);
        _stagesStack.Peek().SetActive(true);
    }

    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
