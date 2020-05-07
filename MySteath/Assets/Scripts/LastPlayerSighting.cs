using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPlayerSighting : MonoBehaviour
{
    //初始位置
    public Vector3 position = new Vector3(1000f, 1000f, 1000f);
    //
    public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f);
    //高亮度
    public float lightHighIntersity = 0.25f;
    //低亮度
    public float lightLowIntersity = 0f;
    public float fadeSpeed = 7f;
    public float musicFadeSpeed = 1f;
    //alarmLight 脚本对象
    private AlarmLight alarmScript;
    //主灯光上的Light对象
    private Light mainLight;
    //背景音乐
    private AudioSource music;
    //主角危险音乐
    private AudioSource panicAudio;
    /**警报音乐*/
    private AudioSource[] sirens;
    private float muteVolum = 0f;
    private float normalVolum = 0.8f;


    void Awake()
    {
        alarmScript = GameObject.FindWithTag(Tags.AlarmLight).GetComponent<AlarmLight>();
        mainLight = GameObject.FindWithTag(Tags.MainLight).GetComponent<Light>();
        music = GetComponent<AudioSource>();
        panicAudio = transform.Find("secondary_music").GetComponent<AudioSource>();
        GameObject[] sirenGameObjects = GameObject.FindGameObjectsWithTag(Tags.Siren);
        sirens = new AudioSource[sirenGameObjects.Length];
        for (int i = 0; i < sirens.Length; ++i)
        {
            sirens[i] = sirenGameObjects[i].GetComponent<AudioSource>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchAlarms();
        MusicFading();
    }

    void SwitchAlarms()
    {
        alarmScript.alarmOn = (position != resetPosition);
        float newIntensity;
        if (position != resetPosition)
        {
            newIntensity = lightLowIntersity;
        }
        else
        {
            newIntensity = lightHighIntersity;
        }

        mainLight.intensity = Mathf.Lerp(mainLight.intensity, newIntensity, fadeSpeed * Time.deltaTime);
        for (int i = 0; i < sirens.Length; i++)
        {
            if (position != resetPosition && !sirens[i].isPlaying)
            {
                sirens[i].Play();
            }
            else if(position == resetPosition)
            {
                sirens[i].Stop();
            }
        }
    }

    void MusicFading ()
    {
        if (position != resetPosition)
        {
            music.volume = Mathf.Lerp(music.volume, muteVolum, musicFadeSpeed * Time.deltaTime);
            panicAudio.volume = Mathf.Lerp(panicAudio.volume, normalVolum, musicFadeSpeed * Time.deltaTime);
        }
        else
        {
            music.volume = Mathf.Lerp(music.volume, normalVolum, musicFadeSpeed * Time.deltaTime);
            panicAudio.volume = Mathf.Lerp(panicAudio.volume, muteVolum, musicFadeSpeed * Time.deltaTime);
        }

    }
}
