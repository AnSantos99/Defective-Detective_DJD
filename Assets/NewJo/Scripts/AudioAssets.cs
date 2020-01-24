using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class AudioAssets
{
    public string name;

    public AudioClip clip;
    [SerializeField]public AudioMixerGroup audioMixer;
    [Range(0f, 1f)]
    public float volume;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
