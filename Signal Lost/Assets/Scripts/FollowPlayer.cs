using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    public bool isCollected{get;set;}
    public Animator animator;
    SpriteSwapping spriteSwapping;
    public BoxCollider2D boxCollider2D;

    public Vector3 origin;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteSwapping = player.GetComponent<SpriteSwapping>();
        origin = transform.position;
        boxCollider2D = GetComponent<BoxCollider2D>();
        
    }
    void Update()
    {
        if(isCollected){            
            animator.enabled = false;
            transform.position = player.position + player.TransformDirection(offset);
            transform.rotation = player.rotation;
            boxCollider2D.enabled = false;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!isCollected){
            spriteSwapping.amountOfParts++;    
            boxCollider2D.enabled = true;       
        }
        isCollected = true;
        
        
    }
}
