using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "So_Key", menuName = "Keys")]
public class So_Key : ScriptableObject
{
    public Vector3 origin;
    public bool isCollected;
    public bool keyReset;
    public Animator animator;

    public void KeyReset()
    {
        origin = new Vector3(origin.x, origin.y, 0);
        isCollected = false;
        keyReset = false;
        animator.enabled = true;
    }
}

