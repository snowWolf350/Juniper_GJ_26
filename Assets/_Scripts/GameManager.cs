using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public event EventHandler OnGameStateChanged;

    float _countDownTimer = 3.4f;
    public enum gameState
    {
        countDown,playing,paused,caught,end
    }

    gameState _currentGameState = gameState.countDown;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
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
                break;
            case gameState.paused:
                break;
            case gameState.caught:
                break;
            case gameState.end:
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
