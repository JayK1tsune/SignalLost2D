using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    public Vector3 originalPosition;
    AudioSource audioSource;
        
    void Start()
    {
        originalPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        audioSource.Play();
    }

}

