using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
   GameObject YellowKey;
   GameObject GreenKey;
   GameObject BlueKey;
   GameObject RedKey;
   FollowPlayer followPlayer;
   public bool keyReset;

    void Start()
    {
        followPlayer = FindObjectOfType<FollowPlayer>();
        YellowKey = GameObject.Find("YellowKey");
        GreenKey = GameObject.Find("GreenKey");
        BlueKey = GameObject.Find("BlueKey");
        RedKey = GameObject.Find("RedKey");
        keyReset = false;
    }

    public void KeyReset()
    {   
        YellowKey.transform.position = followPlayer.origin;
        GreenKey.transform.position = followPlayer.origin;  
        BlueKey.transform.position = followPlayer.origin;
        RedKey.transform.position = followPlayer.origin;
        followPlayer.isCollected = false;
        followPlayer.animator.enabled = true;

    }
}
