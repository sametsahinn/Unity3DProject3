using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [SerializeField] AudioClip clip;

    SoundController[] soundControllers;

    void Awake()
    {
        SetSingletonThisGameObject(this);

        soundControllers = GetComponentsInChildren<SoundController>();
    }

    void Start()
    {
        soundControllers[0].SetClip(this.clip);
        soundControllers[0].PlaySound(Vector3.zero);
    }

    public void RangeAttackSound(AudioClip clip, Vector3 position)
    {
        soundControllers[1].PlaySound(position);
        soundControllers[1].SetClip(clip); 
    }

    public void MeleeAttackSound(AudioClip clip, Vector3 position)
    {
        for (int i = 2; i < soundControllers.Length; i++)
        {
            if (soundControllers[i].IsPlaying) continue;

            soundControllers[i].SetClip(clip);
            soundControllers[i].PlaySound(position);
            break;
        }
    }
}
