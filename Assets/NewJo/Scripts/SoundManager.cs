using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager: MonoBehaviour
{
    public AudioAssets[] sounds;

    private void Awake()
    {
        foreach (AudioAssets s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        AudioAssets s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
