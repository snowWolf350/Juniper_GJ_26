using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CountDownText;

    private Animator animator;
    int previousCountDownNumber =0;
    const string NUMBER_POPUP = "NumberPopup";

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += Instance_OnGameStateChanged;
        animator = GetComponent<Animator>();
        
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateChanged -= Instance_OnGameStateChanged;
    }

    private void Update()
    {
        int countDownNumber = Mathf.RoundToInt(GameManager.Instance.GetCountDownTimer());

        if (previousCountDownNumber != countDownNumber)
        {
            previousCountDownNumber = countDownNumber;
            animator.SetTrigger(NUMBER_POPUP);

            CountDownText.text = countDownNumber.ToString();
        }

    }

    private void Instance_OnGameStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.GameIsCountDown())
        {
            Show();
        }
        else
            Hide();
    }

    void Show()
    {
        CountDownText.gameObject.SetActive(true);
    }
    void Hide()
    {
        CountDownText.gameObject.SetActive(false);
    }
}
