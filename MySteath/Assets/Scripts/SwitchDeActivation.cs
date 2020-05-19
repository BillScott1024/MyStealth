using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDeActivation : MonoBehaviour
{

    public GameObject laser;
    public Material unlockedMat;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaserDeactivation() {
        laser.SetActive(false);
        Renderer screen = transform.Find("prop_switchUnit_screen").GetComponent<Renderer>();
        screen.material = unlockedMat;
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetButton("Switch"))
            {
                LaserDeactivation();
            }
        }
    }

}
