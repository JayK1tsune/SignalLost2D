using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimations : MonoBehaviour
{
    SpriteSwapping spriteSwapping;
    Animator animator;
    [SerializeField] GameObject player;
    

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteSwapping = player.GetComponent<SpriteSwapping>();
    }

    void Update()
    {
        if (spriteSwapping.isWhole)
        {
            animator.SetTrigger("IsWhole");
        }
        if(spriteSwapping.isWhole == false){
            animator.ResetTrigger("IsWhole");
        }
    }
}
