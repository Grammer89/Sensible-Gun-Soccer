using UnityEngine;

public class AudioKickEnemy : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SoundKickEnemy()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();

        }
    }
}
