using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    int _score = 0;

    const float _playerSpeed = 10f;//bu değer sabit ,değiştirilemez

    private Vector3 _initiaPosition;

    GameManager gameManager;
    
    private void Start()
    {
        _scoreText.text = "Score: " + _score;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        _initiaPosition = GetComponent<Rigidbody>().position;        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        GetComponent<Rigidbody>().velocity = movement * _playerSpeed;
    }

    public void Reset()
    {
        GetComponent<Rigidbody>().position = _initiaPosition;
    }

    public void ChangeScore(int point)
    {
        _score += point;
        ShowScore();
    }

    private void ShowScore()
    {
        _scoreText.text = "Score: " + _score;
    }

    public void LoseGame()
    {
        gameManager.SetMaxScore(_score);
        _score = 0;
    }

    public void WinGame()
    {
        gameManager.SetMaxScore(_score);
    }

}
