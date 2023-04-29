using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwapping : MonoBehaviour
{
    public Sprite[] characterSprites;
    SpriteRenderer spriteRenderer;
    public int amountOfParts;
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
        case 0:
            spriteRenderer.sprite = characterSprites[0];
            break;
        case 1:
            spriteRenderer.sprite = characterSprites[1];
            break;
        case 2:
            spriteRenderer.sprite = characterSprites[2];
            break;
        case 3:
            spriteRenderer.sprite = characterSprites[3];
            break;
        case 4:
            spriteRenderer.sprite = characterSprites[4];
            isWhole = true;
            break;
        default:
            spriteRenderer.sprite = characterSprites[0];
            break;

        }
    }
}
