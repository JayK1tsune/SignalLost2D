using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlatformLight : MonoBehaviour
{
    public GameObject player;
    public Light2D Platforms;
    
    void Awake()
    {
        Platforms = GetComponent<Light2D>();
        Platforms.intensity = 0f;
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject == player){
            Platforms.intensity = 3.02f;
        }
            
         
        
    }
    void OnTriggerExit2D(Collider2D other){
        
            Platforms.intensity = 0f;
        
         
    }
}
