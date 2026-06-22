using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    PlayerInput _playerInput;

    public static event EventHandler OnPlayerTurn;

    public static event EventHandler<OnArrowPressedEventArgs> OnArrowPressed;
    public class OnArrowPressedEventArgs : EventArgs
    {
        public Vector2 arrowDir;
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }
    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    private void Start()
    {
        _playerInput.player.turn.performed += Turn_performed;
        _playerInput.player.arrow.performed += Arrow_performed; ;
    }

    private void Arrow_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnArrowPressed.Invoke(this, new OnArrowPressedEventArgs
        {
            arrowDir = obj.ReadValue<Vector2>(),
        });
    }

    private void Turn_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerTurn?.Invoke(this,EventArgs.Empty);
    }
}
