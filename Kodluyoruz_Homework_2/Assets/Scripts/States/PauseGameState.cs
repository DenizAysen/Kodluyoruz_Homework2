using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameState : MonoBehaviour,IState
{
   [SerializeField] private GameObject _pauseScreen;
    private Button _resumeButton;

    public void Enter()
    {
        _pauseScreen.SetActive(true);
        _resumeButton = _pauseScreen.GetComponentInChildren<Button>();
        _resumeButton.onClick.AddListener(HandlePauseButton);
        Time.timeScale = 0f;
    }

    public void Exit()
    {
        _pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

   

    private void HandlePauseButton()
    {
        FindObjectOfType<GameManager>().SetState(StateType.GameState);
       
    }
}
