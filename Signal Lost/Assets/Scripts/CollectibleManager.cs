using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public CollectibleObject[] requiredCollectibles;
    public List<CollectibleObject> collectedCollectibles = new List<CollectibleObject>();

    public bool resetCollectibles = false;

    public void ResetCollectedCollectibles()
    {
        foreach (CollectibleObject c in collectedCollectibles)
        {
            c.transform.position = c.originalPosition;
        }
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



