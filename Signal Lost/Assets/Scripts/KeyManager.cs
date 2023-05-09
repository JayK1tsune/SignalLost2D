using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
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
        YellowKey = GameObject.Find("YellowKey");
        GreenKey = GameObject.Find("GreenKey");
        BlueKey = GameObject.Find("BlueKey");
        RedKey = GameObject.Find("RedKey");
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
        YellowKey.transform.position = yellowKeyOrigin;
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
        RedKey.GetComponent<FollowPlayer>().boxCollider2D.enabled = true;
        keyReset = true;
        
    }

}
