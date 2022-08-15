using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
    [SerializeField] private AudioClip _wingFlapClip;
    [SerializeField] private AudioClip _losingClip;
    [SerializeField] private AudioClip _scorePointClip;

    private AudioSource _audioSource;

    private void Start() =>
        _audioSource = GetComponent<AudioSource>();

    public void PlayWingFlap() =>
        _audioSource.PlayOneShot(_wingFlapClip);

    public void PlayLosing() =>
        _audioSource.PlayOneShot(_losingClip);

    public void PlayScorePoint() =>
        _audioSource.PlayOneShot(_scorePointClip);
}
