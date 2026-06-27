using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] Button _continueButton;
    [SerializeField] Button _retryButton;
    [SerializeField] Button _mainMenuButton;
    [SerializeField] Button _quitButton;

    private void Awake()
    {
        _continueButton.onClick.AddListener(() =>
        {
            GameManager.Instance.SetGameState(GameManager.gameState.playing);
            Hide();
        });
        _retryButton.onClick.AddListener(() =>
        {
            SceneLoader.LoadGame();
        });
        _mainMenuButton.onClick.AddListener(() => 
        {
            SceneLoader.LoadMainMenu();
        });
        _quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += Instance_OnGameStateChanged;
        Hide();
    }

    private void Instance_OnGameStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.GameIsPaused())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    public void RetryButton()
    {
        SceneLoader.LoadGame();
    }

    public void MainMenuButton()
    {
        SceneLoader.LoadMainMenu();
    }

    public void QuitButton()
    {
        Application.Quit();
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
