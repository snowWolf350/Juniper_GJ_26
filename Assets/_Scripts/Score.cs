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
        ArrowGenerator.OnWrongArrowPressed += ArrowGenerator_OnWrongArrowPressed;
    }
    private void OnDestroy()
    {
        ArrowGenerator.OnCorrectArrowPressed -= ArrowGenerator_OnCorrectArrowPressed;
        ArrowGenerator.OnArrowListGenerated -= ArrowGenerator_OnArrowListGenerated;
        ArrowGenerator.OnWrongArrowPressed -= ArrowGenerator_OnWrongArrowPressed;
    }

    private void ArrowGenerator_OnArrowListGenerated(object sender, ArrowGenerator.OnArrowGeneratedEventArgs e)
    {
        if (firstList)
        {
            firstList = false;
        }
        if (firstList) return;

        AddScore(_arrowListScore);
    }

    private void ArrowGenerator_OnWrongArrowPressed(object sender, ArrowGenerator.OnCorrectArrowPressedEventArgs e)
    {
        AddScore(-(e.arrowIndex) * _arrowScore);
    }

    private void ArrowGenerator_OnCorrectArrowPressed(object sender, ArrowGenerator.OnCorrectArrowPressedEventArgs e)
    {
        AddScore(_arrowScore);
    }

    void AddScore(int scoreToAdd)
    {
        _score += scoreToAdd;

        _scoreText.text = "Score : " + _score;
    }
    public static int GetScore()
    {
        return _score; 
    }
}
