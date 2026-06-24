using UnityEngine;

public class Boss : MonoBehaviour
{
    
    enum bossState
    {
        idle,patrolling,peak,walkBack
    }

    bossState _currentBossState;

    float _maxIdleTime = 6;
    float _minIdleTime = 3;
    float _idleTimer;

    float _maxWalkTime = 2;
    float _patrolDirection;
    float t = 0;
    Transform _destinationTransform;
    [SerializeField] Transform _startTransform;
    [SerializeField] Transform _leftTransform;
    [SerializeField] Transform _rightTransform;

    float _checkDuration = 2;

    void Start()
    {
        SetBossState(bossState.idle);
    }

    void Update()
    {
        switch (_currentBossState)
        {
            case bossState.idle:
                if(_currentBossState != bossState.idle)
                {
                    SetBossState(bossState.idle);
                }
                _idleTimer -= Time.deltaTime;
                if( _idleTimer < 0)
                {
                    //idle time over patrol time
                    SetBossState(bossState.patrolling);
                }
                break;
            case bossState.patrolling:
                transform.position = Vector3.Lerp(_startTransform.position, _destinationTransform.position, t);
                t += Time.deltaTime/_maxWalkTime;
                if (t > 1)
                {
                    t = 0;
                    transform.position = _destinationTransform.position;
                    SetBossState(bossState.peak);
                }
                break;
            case bossState.peak:
                if (Player.PlayerInOfficeMode())
                {
                    Debug.Log("Player is in office mode");
                }
                else
                {
                    Debug.Log("Player is in game mode");
                }
                t += Time.deltaTime;
                if(t>_checkDuration)
                {
                    t = 0;
                    SetBossState(bossState.walkBack);
                }
                ;
                break;
            case bossState.walkBack:
                transform.position = Vector3.Lerp(_destinationTransform.position, _startTransform.position, t);
                t += Time.deltaTime / _maxWalkTime;
                if (t > 1)
                {
                    t = 0;
                    transform.position = _startTransform.position;
                    SetBossState(bossState.idle);
                }
                break;
        }
    }

    void SetBossState(bossState bossState)
    {
        _currentBossState=bossState;
        if (bossState == bossState.idle)
        {
            _idleTimer = Random.Range(_minIdleTime, _maxIdleTime);
        }
        else if (bossState == bossState.patrolling)
        {
            _patrolDirection = Random.Range(0, 2);
            if(_patrolDirection == 0)
                _destinationTransform = _leftTransform;
            else
                _destinationTransform = _rightTransform;
        }
    }
}
