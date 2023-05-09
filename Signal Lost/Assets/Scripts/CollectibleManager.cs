using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public CollectibleObject[] requiredCollectibles;
    public List<CollectibleObject> collectedCollectibles = new List<CollectibleObject>();
    
    SpriteSwapping spriteSwapping;
    public bool resetCollectibles = false;
    [SerializeField] KeyManager keyManager;
   

    void Awake()
    {
        keyManager = keyManager.GetComponent<KeyManager>();
        
        spriteSwapping = FindObjectOfType<SpriteSwapping>();
    }
    public void ResetCollectedCollectibles()
    {
        foreach (CollectibleObject key in collectedCollectibles)
        {
            spriteSwapping.amountOfParts--;
            //key.transform.position = key.originalPosition;       
        }
        
        StartCoroutine(keyManager.KeyReset());
        collectedCollectibles.Clear();
        resetCollectibles = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CollectibleObject collectible = other.GetComponent<CollectibleObject>();
        if (collectible != null && !collectedCollectibles.Contains(collectible))
        {
            collectedCollectibles.Add(collectible);

            if (collectedCollectibles.Count == requiredCollectibles.Length)
            {
                for (int i = 0; i < requiredCollectibles.Length; i++)
                {
                    if (collectedCollectibles[i] != requiredCollectibles[i])
                    {
                        resetCollectibles = true;
                        break;
                    }
                }

                if (resetCollectibles)
                {
                    ResetCollectedCollectibles();
                    Debug.Log("Reset has been called");
                }
            }
        }
    }
}



