using TMPro;
using UnityEngine;

public class WinScreenUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _titleText;
    [SerializeField] TextMeshProUGUI _scoreText;
    void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        Boss.OnPlayerCaught += Boss_OnPlayerCaught;
        Hide();
    }
    private void Boss_OnPlayerCaught(object sender, System.EventArgs e)
    {
        Show();
        _titleText.text = "Too bad ! you got caught, better luck next time";
        _scoreText.text = "Score : " + Score.GetScore().ToString();
    }

    private void GameManager_OnGameStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.GameIsWon())
        {
            Show();
            _titleText.text = "Congragulations ! You played games at work without Getting caught";
            _scoreText.text = "Score : " + Score.GetScore().ToString();
        }
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateChanged -= GameManager_OnGameStateChanged;
        Boss.OnPlayerCaught -= Boss_OnPlayerCaught;
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
