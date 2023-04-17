
using UnityEngine;
using SignalLost;
using System.Collections;

namespace SignalLost{
public class colourDetect : MonoBehaviour
{
    public Transform target; // the object the player is trying to find
    public Color[] colors; // an array of colors to use based on distance
    public float[] distances; 
    public float closeDistance = 2.0f; 
    public float farDistance = 10.0f; 
    public float pulseFrequency = 1.0f; 
    public bool scriptEnabled;
    public float basePulseFrequency = 1.0f;
    public float lineDuration = 0.1f;
    public float lineWidth = 1f;
    private SpriteRenderer spriteRenderer;
    public LineRenderer lineRenderer;
    private float lineTimer = 0.0f;



       private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
         
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }

    private void Update()
    {
        if (scriptEnabled){
            //Setting Up inital lineRenderer.
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, target.position);

            
            lineRenderer.enabled = true;
            StartCoroutine(DisableLineRenderer());
        }
        if (lineTimer > 0.0f)
        {
            lineTimer -= Time.deltaTime;
            if (lineTimer <= 0.0f)
            {
                lineRenderer.enabled = false;
            }
        }
        if (!scriptEnabled)
        {
            spriteRenderer.color = Color.white;
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        int colourIndex;
        if (distance <= closeDistance)
        {
            colourIndex = 0;
        }
        else if (distance >= farDistance)
        {
            colourIndex = colors.Length - 1;
        }
        else
        {
            float t = (distance - closeDistance) / (farDistance - closeDistance);
            colourIndex = Mathf.FloorToInt(t * (colors.Length - 1));

            float pulseFrequency = basePulseFrequency;
            if (colourIndex == 0)
            {
                float colourDiff = Mathf.Abs(colors[1].r - colors[0].r) + Mathf.Abs(colors[1].g - colors[0].g) + Mathf.Abs(colors[1].b - colors[0].b);
                pulseFrequency += colourDiff+1;
            }
            else if (colourIndex == colors.Length - 1)
            {
                float colourDiff = Mathf.Abs(colors[colors.Length - 1].r - colors[colors.Length - 2].r) + Mathf.Abs(colors[colors.Length - 1].g - colors[colors.Length - 2].g) + Mathf.Abs(colors[colors.Length - 1].b - colors[colors.Length - 2].b);
                pulseFrequency += colourDiff;
            }
            else
            {
                float colourDiff = Mathf.Abs(colors[colourIndex + 1].r - colors[colourIndex - 1].r) + Mathf.Abs(colors[colourIndex + 1].g - colors[colourIndex - 1].g) + Mathf.Abs(colors[colourIndex + 1].b - colors[colourIndex - 1].b);
                pulseFrequency += colourDiff;
            }

            float pulse = Mathf.Sin(Time.time * pulseFrequency);
            float pulseAmount = 0.5f - 0.5f * pulse;
            spriteRenderer.color = colors[colourIndex] * pulseAmount;
            return;
        }

        spriteRenderer.color = colors[colourIndex];

        
    }
    IEnumerator DisableLineRenderer(){
    yield return new WaitForSeconds(0.2f);
    lineRenderer.enabled = false;
    }

}
}
 

