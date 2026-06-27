using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public event EventHandler OnGameStateChanged;

    float _countDownTimer = 3.4f;

    float _gameTimeMax = 180;
    float _gameTimer;
    [SerializeField] Image _countDownImage;

    public enum gameState
    {
        countDown,playing,paused,caught,won
    }

    gameState _currentGameState = gameState.countDown;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        _gameTimer = _gameTimeMax;
    }

    private void Update()
    {
        switch (_currentGameState)
        {
            case gameState.countDown:
                _countDownTimer -= Time.deltaTime;

                if (_countDownTimer < 0)
                    SetGameState(gameState.playing);
                break;
            case gameState.playing:
                _gameTimer -= Time.deltaTime;

                _countDownImage.fillAmount = _gameTimer / _gameTimeMax;

                if(_gameTimer <0)
                    SetGameState(gameState.won);
                break;
            case gameState.paused:
                break;
            case gameState.caught:
                break;
            case gameState.won:

                break;
        }
    }

    public void SetGameState(gameState state)
    {
        _currentGameState = state;

        OnGameStateChanged?.Invoke(this, EventArgs.Empty);

        if (state == gameState.playing || state == gameState.countDown)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    public float GetCountDownTimer()
    {
        return _countDownTimer;
    }
    public bool GameIsWon()
    {
        return _currentGameState == gameState.won;
    }
    public bool GameIsCaught()
    {
        return _currentGameState == gameState.caught;
    }
    public bool GameIsPaused()
    {
        return _currentGameState == gameState.paused;
    }
    public bool GameIsPlaying()
    {
        return _currentGameState == gameState.playing;
    }

    public bool GameIsCountDown()
    {
        return _currentGameState == gameState.countDown;
    }
}
