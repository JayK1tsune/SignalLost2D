using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLoop : MonoBehaviour
{
    [SerializeField] GameObject player;
    SpriteSwapping spriteSwapping;  

    void Awake()
    {
        spriteSwapping = player.GetComponent<SpriteSwapping>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(spriteSwapping.amountOfParts >= 4){
            SceneManager.LoadScene(1);
        }
        Debug.Log("Player hit");
    }

}
