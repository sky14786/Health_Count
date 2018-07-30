using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public InputField Delay, Count, Rest;
    public bool isPlaying;
    public float DelayTime, TimeCount, RealTime;
    public int PlayCount, Play;
    public AudioSource Speak;
    public List<AudioClip> Clip = new List<AudioClip>();
    public Button StartButton, StopButton,ResetButton;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StartButton.onClick.AddListener(() =>
        {
            int.TryParse(Count.text, out PlayCount);
            float.TryParse(Delay.text, out DelayTime);
            isPlaying = true;
        });
        StopButton.onClick.AddListener(() =>
        {
            isPlaying = false;
        });
        ResetButton.onClick.AddListener(() =>
        {
            isPlaying = false;
            Play = 0;
            Delay.text = "";
            Count.text = "";
        });
    }


    public void _Playing()
    {
        if (Play < PlayCount)
        {
            if (RealTime > 0)
            {
                RealTime -= Time.deltaTime;
            }
            else
            {
                RealTime = DelayTime;
                Speak.PlayOneShot(Clip[Play]);
                Play += 1;
            }
        }
        else
        {
            isPlaying = false;
            Play = 0;
            Delay.text = "";
            Count.text = "";
        }
    }

    public void Update()
    {
        if (isPlaying)
        {
            _Playing();
        }
        if (Application.platform == RuntimePlatform.Android)

        {

            if (Input.GetKey(KeyCode.Escape))

            {
                Application.Quit();
            }
        }

    }


}
