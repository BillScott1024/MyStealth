using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip shoutingClip;
    public float turnSmothing = 15f;
    public float speedDampTime = 0.1f;
    private Animator animator;
    private HashIDs hash;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        hash = GameObject.FindWithTag(Tags.GameController).GetComponent<HashIDs>();
        animator.SetLayerWeight(1, 1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Rotating(float h, float v)
    {
        Vector3 targetDir = new Vector3(h, 0, v);
        Quaternion targetRotation = Quaternion.LookRotation(targetDir, Vector3.up);
        Rigidbody r = GetComponent<Rigidbody>();
        Quaternion newRotation = Quaternion.Lerp(r.rotation, targetRotation, turnSmothing * Time.deltaTime);
        r.MoveRotation(newRotation);
    }

    void MovementManagement(float h, float v, bool sneaking)
    { 
        animator.SetBool(hash.sneakingBool)
    }
}
