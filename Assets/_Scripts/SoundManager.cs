using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _swappingSound;
    [SerializeField] private AudioClip _correctKeySound;
    [SerializeField] private AudioClip _wrongKeySound;
    [SerializeField] private AudioClip _CaughtSound;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Player.OnPlayerSwitch += Player_OnPlayerSwitch;
        ArrowGenerator.OnCorrectArrowPressed += ArrowGenerator_OnCorrectArrowPressed;
        ArrowGenerator.OnWrongArrowPressed += ArrowGenerator_OnWrongArrowPressed;
        Boss.OnPlayerCaught += Boss_OnPlayerCaught;
    }

    private void ArrowGenerator_OnWrongArrowPressed(object sender, ArrowGenerator.OnCorrectArrowPressedEventArgs e)
    {
        _audioSource.PlayOneShot(_wrongKeySound);
    }

    private void Boss_OnPlayerCaught(object sender, System.EventArgs e)
    {
        _audioSource.PlayOneShot(_CaughtSound,1f);
    }
        private void ArrowGenerator_OnCorrectArrowPressed(object sender, ArrowGenerator.OnCorrectArrowPressedEventArgs e)
    {
        _audioSource.PlayOneShot(_correctKeySound, 1.2f);
    }

    private void Player_OnPlayerSwitch(object sender, System.EventArgs e)
    {
        _audioSource.PlayOneShot(_swappingSound, 1.2f);
    }
    private void OnDestroy()
    {
        Player.OnPlayerSwitch -= Player_OnPlayerSwitch;
        ArrowGenerator.OnCorrectArrowPressed -= ArrowGenerator_OnCorrectArrowPressed;
        ArrowGenerator.OnWrongArrowPressed -= ArrowGenerator_OnWrongArrowPressed;
        Boss.OnPlayerCaught -= Boss_OnPlayerCaught;
    }

}