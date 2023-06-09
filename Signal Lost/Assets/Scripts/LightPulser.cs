using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPulser : MonoBehaviour
{
    public float duration;
    public Light2D lt;
    // Start is called before the first frame update
    void Start()
    {
        lt= GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float phi = (Time.time / duration) * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5f + 0.5f;
        lt.intensity = amplitude;
    }
}
