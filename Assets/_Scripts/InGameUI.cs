using System;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] GameObject _inGameUIGO;
    [SerializeField] GameObject _pauseUIGO;

    

    [SerializeField] Button _pauseButton;

    [SerializeField] Animator _scoreAnimator;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(() =>
        {
            GameManager.Instance.SetGameState(GameManager.gameState.paused);
            Hide();
        });
    }
    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        ArrowGenerator.OnCorrectArrowPressed += ArrowGenerator_OnCorrectArrowPressed;
    }

    private void ArrowGenerator_OnCorrectArrowPressed(object sender, ArrowGenerator.OnCorrectArrowPressedEventArgs e)
    {
        _scoreAnimator.SetTrigger("scored");
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }
    private void GameManager_OnGameStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.GameIsPlaying())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    void Show()
    {
        gameObject.SetActive(true);
    }
    void Hide()
    {
        gameObject.SetActive(false);
    }
}
