using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SignalLost{
public class ParallaxEffect : MonoBehaviour
{   
    public Camera cam;
    public Transform followTarget;

    Vector2 startingPos;
    float startingZ;
    Vector2 camMovementSinceStart => (Vector2) cam.transform.position - startingPos;
    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget>0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPos + camMovementSinceStart * parallaxFactor;

        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}

}
