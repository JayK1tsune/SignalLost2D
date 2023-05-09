using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{ 
    public GameObject player;
    public GameObject playerPrefab;
    public GameObject tp_Origin;
    public Transform tp_Prefab;

    void OnTriggerEnter2D(Collider2D other)
    {   
        player.transform.position = tp_Origin.transform.position;

    }
}
