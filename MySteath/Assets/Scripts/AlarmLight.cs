using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    public float fadeSpeed = 2f;
    public float hightIntensity = 4f;
    public float lowIntensity = 0.5f;
    public float changeMargin = 0.2f;
    public bool alarmOn;
    private float targetIntensity;
    private Light alarmLight;


    private void Awake()
    {
        alarmLight = GetComponentInParent<Light>();
        alarmLight.intensity = 0f;
        targetIntensity = hightIntensity;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (alarmOn)
        {
            alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
            CheckTargetIntersity();
        }
        else
        {
            alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, 0f, fadeSpeed * Time.deltaTime);
        }
    }

    void CheckTargetIntersity() 
    {
        if (Mathf.Abs(targetIntensity - alarmLight.intensity) < changeMargin)
        {
            if (targetIntensity == hightIntensity)
            {
                targetIntensity = lowIntensity;
            }
            else
            {
                targetIntensity = hightIntensity;
            }
        }
    }
}
