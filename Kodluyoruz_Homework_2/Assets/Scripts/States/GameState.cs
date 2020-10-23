using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour,IState
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private ObjectPooler _objectPooler;
    [SerializeField] private GameObject _pauseButtonGMO;
    [SerializeField] private TextMeshProUGUI _chanceText;
    [SerializeField] private TextMeshProUGUI _timeText;
    private Coroutine _timeCoroutine;
    private Button _pauseButton;
    private GameManager gameManager;
    int _chance;
    float _time;
    bool _inGameState;
   

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
            Debug.LogError("DropController yok");
        }
        _chance = 3;
        _time = 10f;
        _inGameState = true;
        SetPauseButton();
        _timeText.enabled = true;
        _player.enabled = true;
        _objectPooler.enabled = true;
        _chanceText.enabled = true;
        _chanceText.text = "Chance: " + _chance;
         StartTime();

    }

    public void Exit()
    {
       
        _pauseButtonGMO.SetActive(false);
        _objectPooler.enabled = false;
        _player.enabled = false;       
        _chanceText.enabled = false;
        _timeText.enabled = false;
        _inGameState = false;
    }


    private void SetPauseButton()
    {
        _pauseButtonGMO.SetActive(true);
        _pauseButton = _pauseButtonGMO.GetComponentInChildren<Button>();
        _pauseButton.onClick.AddListener(HandlePauseButton);
    }

    private void HandlePauseButton()
    {
       
        gameManager.SetState(StateType.PauseGameState);
    }

    private IEnumerator RunningTime(float _period)
    {
        WaitForSeconds wait = new WaitForSeconds(_period);

        while (true)
        {
            if(_time > 0)
            {
                _time -= 1f;
                _timeText.text = _time.ToString();
                yield return wait;
            }

            else
            {                
                ChangeWinState();
                break;
            }
         
        }      
    }

    private void StartTime()
    {
        if (_inGameState)
        {
            _timeCoroutine = StartCoroutine(RunningTime(1f));
        }
    }

    public void LoseChance()
    {
        if (_inGameState){
            _chance -= 1;

            _chanceText.text = "Chance: " + _chance;

            if (_chance == 0)
            {
                ChangeLoseState();
            }
        }       
    }

    private void ChangeLoseState()
    {
        _inGameState = false;
         StopCoroutine(_timeCoroutine);
        _player.LoseGame();
         gameManager.SetState(StateType.LoseGameState);
    }

    private void ChangeWinState()
    {
        _player.WinGame();
       gameManager.SetState(StateType.WinGameState);               
    }

}
