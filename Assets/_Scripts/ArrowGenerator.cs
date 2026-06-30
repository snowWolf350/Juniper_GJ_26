using UnityEngine;
using System.Collections.Generic;
using System;

public class ArrowGenerator : MonoBehaviour
{

    public static event EventHandler<OnArrowGeneratedEventArgs> OnArrowListGenerated;
    public static event EventHandler<OnCorrectArrowPressedEventArgs> OnCorrectArrowPressed;
    public static event EventHandler<OnCorrectArrowPressedEventArgs> OnWrongArrowPressed;
    public class OnArrowGeneratedEventArgs :EventArgs
    {
        public List<arrow> generatedArrowList;
    }
    public class OnCorrectArrowPressedEventArgs : EventArgs
    {
        public int arrowIndex;
    }
    [Serializable]
    public enum arrow
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
        _arrowList.Clear();
        GameInput.OnArrowPressed += GameInput_OnArrowPressed;
        GenerateArrowList();
    }

    private void GameInput_OnArrowPressed(object sender, GameInput.OnArrowPressedEventArgs e)
    {
        //allow only when player is in gameMode
        if (Player.PlayerInOfficeMode() == true) return;
        if(GameManager.Instance.GameIsPlaying() == false) return;

        arrow pressedArrowKey = arrow.up;
        
        if(e.arrowDir == Vector2.up) pressedArrowKey = arrow.up;
        else if(e.arrowDir == Vector2.down) pressedArrowKey = arrow.down;
        else if(e.arrowDir == Vector2.left) pressedArrowKey = arrow.left;
        else pressedArrowKey = arrow.right;

        if (pressedArrowKey != _currentArrow)
        {
            OnWrongArrowPressed?.Invoke(this, new OnCorrectArrowPressedEventArgs
            {
                arrowIndex = _currentArrowIndex,
            });
            _currentArrow = _arrowList[0];
            _currentArrowIndex = 0; 
            return;
        }

        OnCorrectArrowPressed?.Invoke(this, new OnCorrectArrowPressedEventArgs
        {
            arrowIndex = _currentArrowIndex,
        });
        _currentArrowIndex++;

        if (_currentArrowIndex >= _maxArrows)
        {
            //finished this arrow set generate a new one 
            _arrowList.Clear();
            GenerateArrowList();
            return;
        }
        _currentArrow = _arrowList[_currentArrowIndex];
    }

    public void GenerateArrowList()
    {
        for (int i = 0; i < _maxArrows; i++)
        {
            arrow generatedArrow = (arrow)UnityEngine.Random.Range(0, 4);
            _arrowList.Add(generatedArrow);
        }
        _currentArrow = _arrowList[0];
        _currentArrowIndex = 0;
        OnArrowListGenerated?.Invoke(this, new OnArrowGeneratedEventArgs
        {
            generatedArrowList = _arrowList,
        });
    }

    private void OnDisable()
    {
        GameInput.OnArrowPressed -= GameInput_OnArrowPressed;
    }
}
