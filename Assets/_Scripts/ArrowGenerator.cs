using UnityEngine;
using System.Collections.Generic;

public class ArrowGenerator : MonoBehaviour
{
    enum arrow
    {
        up,
        down, 
        left, 
        right
    }

    List<arrow> _arrowList;
    arrow _currentArrow;
    int _maxArrows = 4;
    int _currentArrowIndex;

    private void Awake()
    {
        _arrowList = new List<arrow>();
    }
    void Start()
    {
        GameInput.OnArrowPressed += GameInput_OnArrowPressed;
        GenerateArrowKey();
    }

    private void GameInput_OnArrowPressed(object sender, GameInput.OnArrowPressedEventArgs e)
    {
        //allow only when player is in gameMode
        if (Player.PlayerIsOfficeMode() == true) return;

        arrow pressedArrowKey = arrow.up;
        
        if(e.arrowDir == Vector2.up) pressedArrowKey = arrow.up;
        else if(e.arrowDir == Vector2.down) pressedArrowKey = arrow.down;
        else if(e.arrowDir == Vector2.left) pressedArrowKey = arrow.left;
        else if (e.arrowDir == Vector2.right) pressedArrowKey = arrow.right;

        if (pressedArrowKey != _currentArrow)
        {
            Debug.Log("wrong key pressed");
            _currentArrow = _arrowList[0];
            _currentArrowIndex = 0; 
            return;
        }

        Debug.Log("Correct key pressed");
        _currentArrowIndex++;
        Debug.Log(_currentArrowIndex);

        if (_currentArrowIndex >= _maxArrows)
        {
            //finished this arrow set generate a new one 
            _arrowList.Clear();
            GenerateArrowKey();
            return;
        }
        _currentArrow = _arrowList[_currentArrowIndex];
    }

    public void GenerateArrowKey()
    {
        for (int i = 0; i < _maxArrows; i++)
        {
            _arrowList.Add((arrow)Random.Range(0, 4));
        }
        _currentArrow = _arrowList[0];
        _currentArrowIndex = 0;
        Debug.Log(_currentArrow);
    }
}
