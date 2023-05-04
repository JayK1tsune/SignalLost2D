using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwapping : MonoBehaviour
{
    public Sprite[] characterSprites;
    SpriteRenderer spriteRenderer;
    public int amountOfParts;
    public Sprite[] keys;
    public bool isWhole{get; set;}

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        amountOfParts = 0;
        isWhole = false;
    }

    void Update()
    {
        switch (amountOfParts)
        {
        case 4:
            spriteRenderer.sprite = characterSprites[4];
            isWhole = true;
            break;
        }
    }
}
