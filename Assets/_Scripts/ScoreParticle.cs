using TMPro;
using UnityEngine;

public class ScoreParticle : MonoBehaviour
{
    TextMeshProUGUI _scoreText;
    RectTransform _rectTransform;
    Rigidbody2D _rigidBody;

    float _yforce;
    float _yDir;
    float _xforce;
    float _xDir;
    float _ejectForceMax = 250;
    float _ejectForceMin = 500;

    private void Start()
    {
        _rigidBody  = GetComponent<Rigidbody2D>();
        _scoreText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _rectTransform = GetComponent<RectTransform>();

        _yDir = Random.Range(0, 2);
        _xDir = Random.Range(0, 2) == 0 ? 1 : -1;
        _yforce = Random.Range(_ejectForceMin, _ejectForceMax);
        _xforce = Random.Range(_ejectForceMin, _ejectForceMax);

        _rigidBody.AddForce(new Vector2(_xforce * _xDir,_yforce * _yDir),ForceMode2D.Impulse);
    }
    private void Update()
    {
        if(_rectTransform.position.y < -570)
        {
            Destroy(gameObject);
        }
    }
    public void SetScoreText(string  scoreText)
    {
        _scoreText.text = scoreText;
    }
}
