using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    public bool isCollected{get;set;}
    Animator animator;
    SpriteSwapping spriteSwapping;

    public Vector3 origin;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteSwapping = player.GetComponent<SpriteSwapping>();
        origin = transform.position;
        
    }
    void Update()
    {
        if(isCollected){

            animator.enabled = false;
            transform.position = player.position + player.TransformDirection(offset);
            transform.rotation = player.rotation;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!isCollected){
            spriteSwapping.amountOfParts++;           
        }
        isCollected = true;
        
        
    }
}
