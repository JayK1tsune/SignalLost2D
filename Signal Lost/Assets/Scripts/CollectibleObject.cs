using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    public Vector3 originalPosition;
    
    void Start()
    {
        originalPosition = transform.position;
    }
}

