using UnityEngine.Audio;
using UnityEngine;
using System;


public class SoundCaller : MonoBehaviour
{
    public Sound[] sounds;



    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound snd in sounds)
        {
            snd.source = gameObject.AddComponent<AudioSource>();
            snd.source.clip = snd.clip;
            snd.source.volume = snd.volume;

            //snd.source.loop = snd.loop;
        }
    }

    public void Play(string name) 
    {
        Sound snd = Array.Find(sounds, sound => sound.soundName == name);
        snd.source.Play();

        if (snd == null)
        {
            Debug.LogWarning("No sound found with the name: " + name);
            return;
        }
    }

    public void FootStepsSound()
    {
        
    }

    /*
    public void InventorySound()
    {
        if (soundCaller.soundActive == true)
        {
            audioSource[0].enabled = true;

            Debug.Log(soundCaller.soundActive);
                
        }

        /*else 
        {
            audioSource[0].enabled = false;
        }
        
        
            
    }*/

    public void OpenDoorSound() 
    {

    }

    public void CloseDoorSound() 
    {

    }
}
