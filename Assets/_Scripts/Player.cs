using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    static bool _officeMode = true;
    bool _canSwap = true;
    float _swapTimeMax = 2;
    [SerializeField] GameObject _officePlayerGO;
    [SerializeField] GameObject _gamePlayerGO;

    public static event EventHandler OnPlayerSwitch;

    private void Start()
    {
        GameInput.OnPlayerTurn += GameInput_OnSpacebarPressed;
        OnPlayerSwitch?.Invoke(this, EventArgs.Empty);
    }

    private void GameInput_OnSpacebarPressed(object sender, System.EventArgs e)
    {
        if (!_canSwap) return;
        if(GameManager.Instance.GameIsPlaying() == false) return;   
        StartCoroutine(swapPlayer());
    }
    IEnumerator swapPlayer()
    {
        _officeMode = !_officeMode;

        OnPlayerSwitch?.Invoke(this, EventArgs.Empty);
        if (_officeMode)
        {
            _officePlayerGO.SetActive(true);
            _gamePlayerGO.SetActive(false);
        }
        else
        {
            _officePlayerGO.SetActive(false);
            _gamePlayerGO.SetActive(true);
        }

        _canSwap = false;
        yield return new WaitForSeconds(_swapTimeMax);
        _canSwap = true;
    }
    public static bool PlayerInOfficeMode()
    {
        if(_officeMode)return true;
        return false;
    }
}
