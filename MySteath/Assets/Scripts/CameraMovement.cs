using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float smooth = 1.5f;
    private Transform player;
    private Vector3 relCameraPos;
    private float relCameraPosMag;
    private Vector3 newPos;


    private void Awake()
    {
        player = GameObject.FindWithTag(Tags.Player).transform;
        relCameraPos = transform.position - player.position;
        relCameraPosMag = relCameraPos.magnitude - 0.5f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool ViewingPositionCheck(Vector3 checkPos)
    {
        RaycastHit hit;
        if (Physics.Raycast(checkPos, player.position - checkPos, out hit, relCameraPosMag))
        {
            if (hit.transform != player)
            {
                return false;
            }
        }
        newPos = checkPos;
        return true;
    }
}
