using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySound : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

    }

    public void SoundVictory()
    {
        if (_audioSource != null)
        {
            _audioSource.clip = _audioClip;
            _audioSource.Play();

        }
    }
}
