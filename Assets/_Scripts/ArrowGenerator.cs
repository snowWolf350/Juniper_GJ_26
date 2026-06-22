using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    enum arrow
    {
        up,
        down, 
        left, 
        right
    }

    arrow _currentArrow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameInput.OnArrowPressed += GameInput_OnArrowPressed;
        GenerateArrowKey();
    }

    private void GameInput_OnArrowPressed(object sender, GameInput.OnArrowPressedEventArgs e)
    {
        arrow pressedArrowKey = arrow.up;
        
        if(e.arrowDir == Vector2.up) pressedArrowKey = arrow.up;
        else if(e.arrowDir == Vector2.down) pressedArrowKey = arrow.down;
        else if(e.arrowDir == Vector2.left) pressedArrowKey = arrow.left;
        else if (e.arrowDir == Vector2.right) pressedArrowKey = arrow.right;

        if (pressedArrowKey != _currentArrow)
        {
            Debug.Log("wrong key pressed");
            return;
        }

        Debug.Log("Correct key pressed");
        GenerateArrowKey();

    }

    public void GenerateArrowKey()
    {
        _currentArrow =  (arrow)Random.Range(0, 3);
        Debug.Log(_currentArrow);
    }
}
