using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{ 
    public GameObject player;
    public GameObject playerPrefab;
    public GameObject tp_Origin;
    public Transform tp_Prefab;


    void Awake()
    {
      
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {   
        
        player.transform.position = tp_Origin.transform.position;
        Destroy(player);
        Instantiate(playerPrefab, tp_Prefab.position, tp_Prefab.rotation);
    }
}
