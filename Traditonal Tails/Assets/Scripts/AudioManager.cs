using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _musicClip;
    [SerializeField] [Range(0f, 1f)] private float _volume = 1f;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }
        _audioSource.clip = _musicClip;
        _audioSource.volume = _volume;
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        StartCoroutine(FadeInMusic());
    }

    public void StopMusic()
    {
        StartCoroutine(FadeOutMusic());
    }

    private IEnumerator FadeInMusic()
    {
        _audioSource.Play();
        float startVolume = 0f;
        _audioSource.volume = startVolume;

        while (_audioSource.volume < _volume)
        {
            _audioSource.volume += Time.deltaTime / fadeDuration;
            yield return null;
        }

        _audioSource.volume = _volume;
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = _audioSource.volume;

        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        _audioSource.Stop();
        _audioSource.volume = _volume;
    }
}