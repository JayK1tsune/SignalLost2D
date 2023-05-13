using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class ExitLoop : MonoBehaviour
{
    public Light2D lit;
    [SerializeField] GameObject player;
    
    private  SpriteSwapping spriteSwapping;  
    public Light2D dLight;

    void Awake()
    {
        spriteSwapping = player.GetComponent<SpriteSwapping>();
        lit = GetComponentInParent<Light2D>();
        dLight = GetComponentInParent<Light2D>();
    }
    void Update()
    {
        if(spriteSwapping.amountOfParts >= 4){
            lit.color = new Color(0.990566f, 0, 0.6250038f, 1f);
            lit.intensity = 6;
        }
        if(spriteSwapping.amountOfParts <= 3){
            dLight.color = dLight.color;
            dLight.intensity = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(spriteSwapping.amountOfParts >= 4){

            SceneManager.LoadScene(2);
        }
        Debug.Log("Player hit");
    }

}
