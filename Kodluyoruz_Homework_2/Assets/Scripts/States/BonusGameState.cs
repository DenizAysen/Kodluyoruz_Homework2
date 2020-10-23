using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusGameState : MonoBehaviour , IState
{

    [SerializeField] private PlayerController _player;
    [SerializeField] private ObjectPooler _objectPooler;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private GameObject _bonusBG;  
    private GameManager gameManager;
    private Coroutine _timeCoroutine;
    float _time;
    bool _win;
    bool _inBonusState;  

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void Enter()
    {
        
        if (!_player)
        {
            Debug.LogError("PlayerController yok");
        }

        if (!_objectPooler)
        {
            Debug.LogError("ObjectPooler yok");
        }

        _time = 20f;
        _win = false;
        _inBonusState = true;
        _bonusBG.SetActive(true);      
        _player.enabled = true;
        _objectPooler.enabled = true;
        _timeText.enabled = true;
        StartTime();
    }

    public void Exit()
    {
        _bonusBG.SetActive(false);      
        _objectPooler.enabled = false;
        _player.enabled = false;
        _timeText.enabled = false;
    }
    
    void StartTime()
    {
        if (_inBonusState)
        {
            _timeCoroutine = StartCoroutine(RunningTime(1f));
        }
    }


    private IEnumerator RunningTime(float _period)
    {
        WaitForSeconds wait = new WaitForSeconds(_period);

        while (true)
        {
            if (_time > 0)
            {
                _time -= 1f;
                _timeText.text = _time.ToString();
                yield return wait;
            }

            else
            {
                _win = true;
                ChangeState();
                break;
            }

        }
    }

    void ChangeState()
    {
        gameManager.SetState(StateType.WinGameState);
    }

}
