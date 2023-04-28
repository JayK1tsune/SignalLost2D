using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAudio : MonoBehaviour
{
    public float fromSeconds;
    public float toSeconds;
    PlatformLight platformLight;
    [SerializeField] AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        platformLight = GetComponent<PlatformLight>();
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject == platformLight.player){
            audioSource.time = fromSeconds;
            audioSource.Play();
            if(toSeconds>0 && toSeconds > fromSeconds){
                audioSource.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
            }
        }
    }
}

