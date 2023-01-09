using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource audioSource;

    public bool IsPlaying => audioSource.isPlaying;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetClip(AudioClip clip)
    {
        if (clip == audioSource.clip) return;

        audioSource.clip = clip;
    }

    public void PlaySound(Vector3 position)
    {
        if (audioSource.isPlaying) return;

        transform.position = position;
        audioSource.Play();
    }
}
