using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _showGuideButton;
    [SerializeField] Button _hideGuideButton;

    [SerializeField] GameObject _guideGameObject;

    private void Awake()
    {
        _showGuideButton.onClick.AddListener(() =>
        {
            _guideGameObject.SetActive(true);
        });
        _hideGuideButton.onClick.AddListener(() =>
        {
            _guideGameObject.SetActive(false);
        });
    }
    public void RetryButton()
    {
        SceneLoader.LoadGame();
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
