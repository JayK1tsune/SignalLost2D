using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector2 offset;
    private bool isCollected;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + player.TransformDirection(offset);
        transform.rotation = player.rotation;
    }
}
