using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    static int _score;

    int _arrowScore = 5;
    int _arrowListScore = 30;
    bool firstList = false;

    [SerializeField] TextMeshProUGUI _scoreText;

    private void Start()
    {
        ArrowGenerator.OnCorrectArrowPressed += ArrowGenerator_OnCorrectArrowPressed;
        ArrowGenerator.OnArrowListGenerated += ArrowGenerator_OnArrowListGenerated;
    }
    private void OnDestroy()
    {
        ArrowGenerator.OnCorrectArrowPressed -= ArrowGenerator_OnCorrectArrowPressed;
        ArrowGenerator.OnArrowListGenerated -= ArrowGenerator_OnArrowListGenerated;
    }

    private void ArrowGenerator_OnArrowListGenerated(object sender, ArrowGenerator.OnArrowGeneratedEventArgs e)
    {
        if (firstList)
        {
            firstList = false;
        }
        if (firstList) return;

        _score += _arrowListScore;

        _scoreText.text = "Score : " + _score;
    }

    private void ArrowGenerator_OnCorrectArrowPressed(object sender, ArrowGenerator.OnCorrectArrowPressedEventArgs e)
    {
        _score += _arrowScore;
        _scoreText.text = "Score : " + _score;
    }
    public static int GetScore()
    {
        return _score; 
    }
}
