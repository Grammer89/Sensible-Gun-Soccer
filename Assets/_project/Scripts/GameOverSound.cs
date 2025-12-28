using UnityEngine;

public class GameOverSound : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SoundGameOver()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();

        }
    }
}

