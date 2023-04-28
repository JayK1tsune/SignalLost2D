using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathField : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject PlayerPrefab;
    TeleportPlayer teleportPlayer;
    [SerializeField] Transform Tp_Start;


    void OnTriggerEnter2D(Collider2D other)
    {
        Player.transform.position = Tp_Start.transform.position;
    }


}
