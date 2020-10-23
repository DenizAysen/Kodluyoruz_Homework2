using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinGameState : MonoBehaviour , IState
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private TextMeshProUGUI _levelvalue;
    int _level;

    void Start()
    {
        _level = 1;
    }
    public void Enter()
    {
       
        _levelvalue.text = _level.ToString();
        _winScreen.SetActive(true);
    }

    public void Exit()
    {
        _winScreen.SetActive(false);
    }

    public void SetLevel(int level)
    {
        _level = level;
    }

    public void HandleBackButton()
    {
        var gameManager = GameManager.Instance;
        gameManager.SetState(StateType.PreGameState);
    }

    public void HandleNextButton()
    {
        var gameManager = GameManager.Instance;
        if (_level%2 != 0)
        {
            gameManager.SetState(StateType.BonusGameState);
        }

        else
        {
            gameManager.SetState(StateType.GameState);
        }
        _level++;
    }
}
