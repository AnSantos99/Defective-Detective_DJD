using System;
using UnityEngine;

public class SoundManager: MonoBehaviour
{
    // Arry of type AudioAssets to save each gameobject to each indice
    // with sound
    public AudioAssets[] sounds;

    private void Awake()
    {
        // In every asset in sound
        foreach (AudioAssets s in sounds)
        {
            // Add to each object a audioSource component
            s.source = gameObject.AddComponent<AudioSource>();

            // And set a default clip for playing the sound
            s.source.clip = s.clip;

            // Set the volume available
            s.source.volume = s.volume;

            // Set the loop of the sound
            s.source.loop = s.loop;
        }
    }

    /// <summary>
    /// Method that gets the name of the sound and then reuturn the sound
    /// </summary>
    /// <param name="name"> Get the name of the sound</param>
    public void Play(string name)
    {
        // to store the sound
        AudioAssets s = Array.Find(sounds, sound => sound.name == name);

        // Play the sound
        s.source.Play();
    }
}
