using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


[Serializable]
public class Key
{
    public string name;
    public So_Key data;

    public GameObject instance;

}

public class KeyManager : MonoBehaviour
{

    public Key[] keys;

   GameObject YellowKey;
   GameObject GreenKey;
   GameObject BlueKey;
   GameObject RedKey;
   AudioSource audioSource;
   public AudioClip wrongcode;
   public AudioClip rightCode;
   SpriteSwapping spriteSwapping;

   [SerializeField] Vector3 yellowKeyOrigin;
   [SerializeField] Vector3 greenKeyOrigin;
   [SerializeField] Vector3 blueKeyOrigin;
   [SerializeField] Vector3 redKeyOrigin;

   public bool keyReset;

    void Start()
    {
        spriteSwapping = FindObjectOfType<SpriteSwapping>();
        audioSource = GetComponent<AudioSource>();
        keyReset = false;
    }
    void Update()
    {
        if(spriteSwapping.isWhole){
            audioSource.PlayOneShot(rightCode, 0.5f);
        }
    }

    public IEnumerator KeyReset()
    {
        audioSource.PlayOneShot(wrongcode);
        yield return new WaitForSeconds(3.2f);
        foreach (var k in keys)
        {
          
            FollowPlayer i = k.instance.GetComponent<FollowPlayer>();

            i.isCollected = false;
            i.animator.enabled = true;
            i.boxCollider2D.enabled = true;

            k.instance.transform.position = k.data.origin;
        }


/*         YellowKey.transform.position = yellowKeyOrigin;
        GreenKey.transform.position = greenKeyOrigin;  
        BlueKey.transform.position = blueKeyOrigin;
        RedKey.transform.position = redKeyOrigin;
        YellowKey.GetComponent<FollowPlayer>().isCollected=false;
        GreenKey.GetComponent<FollowPlayer>().isCollected=false;
        BlueKey.GetComponent<FollowPlayer>().isCollected=false;
        RedKey.GetComponent<FollowPlayer>().isCollected=false;
        YellowKey.GetComponent<FollowPlayer>().animator.enabled = true;
        GreenKey.GetComponent<FollowPlayer>().animator.enabled = true;
        BlueKey.GetComponent<FollowPlayer>().animator.enabled = true;
        RedKey.GetComponent<FollowPlayer>().animator.enabled = true;
        YellowKey.GetComponent<FollowPlayer>().boxCollider2D.enabled = true;
        GreenKey.GetComponent<FollowPlayer>().boxCollider2D.enabled = true;
        BlueKey.GetComponent<FollowPlayer>().boxCollider2D.enabled = true;
        RedKey.GetComponent<FollowPlayer>().boxCollider2D.enabled = true; */
        keyReset = true;
        
    }

}
