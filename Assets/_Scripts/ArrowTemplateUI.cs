using UnityEngine;
using UnityEngine.UI;

public class ArrowTemplateUI : MonoBehaviour
{
    [SerializeField] Image _backGroundSprite;
    [SerializeField] Image _arrowSprite;
    [SerializeField] Sprite _upSprite;
    [SerializeField] Sprite _downSprite;
    [SerializeField] Sprite _leftSprite;
    [SerializeField] Sprite _rightSprite;
    public void SetArrow(ArrowGenerator.arrow arrowDir)
    {
        Sprite arrowSprite = null;
        switch (arrowDir)
        {
            case ArrowGenerator.arrow.up:
                arrowSprite = _upSprite;
                break;
            case ArrowGenerator.arrow.down:
                arrowSprite = _downSprite;
                break;
            case ArrowGenerator.arrow.left:
                arrowSprite = _leftSprite;
                break;
            case ArrowGenerator.arrow.right:
                arrowSprite = _rightSprite;
                break;
        }

        _arrowSprite.sprite = arrowSprite;
    }

    public void SetArrowStatus(Color color)
    {
        _backGroundSprite.color = color;
    }
}
