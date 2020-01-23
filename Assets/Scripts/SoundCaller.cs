using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCaller : MonoBehaviour
{
    public AudioSource audioSource;

    public InteractableObjects soundCaller;

    bool played = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        InventorySound();
    }

    public void FootStepsSound()
    {
        
    }

    public void InventorySound()
    {
        if (soundCaller.soundActive == true)
        {
            audioSource.enabled = true;
            //audioSource.Play();
            Debug.Log(soundCaller.soundActive);
                
        }

        else 
        {
            audioSource.enabled = false;
        }
        
        
            
    }

    public void OpenDoorSound() 
    {

    }

    public void CloseDoorSound() 
    {

    }
}
