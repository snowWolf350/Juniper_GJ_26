using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool _officePlayer = true;
    bool _canSwap = true;
    float _swapTimeMax = 2;
    [SerializeField] GameObject _officePlayerGO;
    [SerializeField] GameObject _gamePlayerGO;

    private void Start()
    {
        GameInput.OnPlayerTurn += GameInput_OnPlayerTurn;
    }

    private void GameInput_OnPlayerTurn(object sender, System.EventArgs e)
    {
        if (!_canSwap) return;
        StartCoroutine(swapPlayer());
        Debug.Log("Player turned");
    }
    IEnumerator swapPlayer()
    {
        _officePlayer = !_officePlayer;
        if (transform.childCount != 0)
        {
            //there is a child here
            Destroy(transform.GetChild(0).gameObject);
        }

        if (_officePlayer)
        {
            Instantiate(_officePlayerGO,transform);
        }
        else
        {
            Instantiate(_gamePlayerGO,transform); 
        }

        _canSwap = false;
        yield return new WaitForSeconds(_swapTimeMax);
        _canSwap = true;
    }
}
