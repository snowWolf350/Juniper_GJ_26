using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    static bool _officeMode = true;
    bool _canSwap = true;
    float _swapTimeMax = 2;
    float _swapTimer;
    [SerializeField] GameObject _officePlayerGO;
    [SerializeField] GameObject _gamePlayerGO;
    [SerializeField] Image _swapTiemrImage;

    public static event EventHandler OnPlayerSwitch;

    Animator _animator;

    private void Start()
    {
        GameInput.OnPlayerTurn += GameInput_OnSpacebarPressed;
        OnPlayerSwitch?.Invoke(this, EventArgs.Empty);
        _animator = GetComponent<Animator>();
    }

    private void GameInput_OnSpacebarPressed(object sender, System.EventArgs e)
    {
        if (!_canSwap) return;
        if(GameManager.Instance.GameIsPlaying() == false) return;   
        StartCoroutine(swapPlayer());
    }
    private void Update()
    {
        if (!_canSwap)
        {
            //player just swapped
            _swapTimer += Time.deltaTime;
            _swapTiemrImage.fillAmount = _swapTimer / _swapTimeMax;

            if (_swapTimer > _swapTimeMax)
            {
                _swapTimer = 0;
                _swapTiemrImage.fillAmount = 0;
            }
        }
    }

    IEnumerator swapPlayer()
    {
        _animator.SetTrigger("spin");

        yield return new WaitForSeconds(0.3f);

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
