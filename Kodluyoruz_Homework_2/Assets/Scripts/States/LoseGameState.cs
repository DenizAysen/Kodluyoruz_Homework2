using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseGameState : MonoBehaviour,IState
{
   [SerializeField] private GameObject _loseScreen;
    //  [SerializeField] private Button _returnButton;
    private WinGameState _winGameState;
    private void Start()
    {
        _winGameState = FindObjectOfType<WinGameState>();
    }

    public void Enter()
    {
        _loseScreen.SetActive(true);
       
    }

    public void Exit()
    {
        _loseScreen.SetActive(false);
    }

    public void HandleReturnButton()
    {
        _winGameState.SetLevel(0);
        var gameManager = GameManager.Instance;
       gameManager.SetState(StateType.PreGameState);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
