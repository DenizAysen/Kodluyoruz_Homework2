using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreGameState : MonoBehaviour,IState
{

    [SerializeField] private GameObject _waitScreen;
    [SerializeField] private TextMeshProUGUI _waitText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
   
    private Coroutine _coroutine;
    private bool _isWaitingToStart;


  

    public void Enter()
    {
        Debug.Log("Entered Pre Game State");
       // Debug.Log(gameManager.GetMaxScore() + "");
        _isWaitingToStart = true;
        _coroutine = StartCoroutine(WaitForStart());
        _waitScreen.SetActive(true);
        _bestScoreText.text = "" + GameManager.Instance.GetMaxScore();
    }

    public void Exit()
    {
        _isWaitingToStart = false;
        StopCoroutine(_coroutine);
        _waitScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FindObjectOfType<GameManager>().SetState(StateType.GameState);
            Exit();
        }
    }


    private IEnumerator WaitForStart()
    {
        float t = 0f;
        while (_isWaitingToStart)
        {
            var value = Mathf.PingPong(t, 0.5f) + 0.5f;
            _waitText.color = new Color(1, 1, 1, value);
            yield return null;
            t += Time.deltaTime;

        }       
    }
}
