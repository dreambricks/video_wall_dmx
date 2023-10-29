using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.Video;

public class VideoManagerSender : MonoBehaviour
{
    private VideoPlayer player;
    private float masterDelay;
    private bool isMessageSent;
    private bool isPlaying;
    private bool prevIsPlaying;

    public int totalCount;
    public int countPlayed;
    public bool controlSound;
    
    DateTime timePassed;
    DateTime playStartTime;



    public ArduinoCommunicationSender arduinoCommunicationSender;
   

    void OnEnable()
    {
        Debug.Log("OnEnable");
        player = GetComponent<VideoPlayer>();
        DisplaySetup loadedData = SaveManager.LoadFromJsonFile<DisplaySetup>("display_data.json");
        masterDelay = float.Parse(loadedData.NetworkDisplay.MasterExtraDelay);

        isMessageSent = false;
        isPlaying = false;

        Debug.Log("Master Delay: " + masterDelay);
        totalCount = int.Parse(loadedData.VideoSettings.CountPlayed);
        controlSound = bool.Parse(loadedData.VideoSettings.SoundControl);

        countPlayed = totalCount;
        player.SetDirectAudioMute(0, false);


    }

    // Update is called once per frame
    void Update()
    {
        PlayVideo();

    }

    void PlayVideo()
    {

        if (!isMessageSent && player.isPlaying == false && isPlaying == false)
        {
            if (countPlayed != 0 && controlSound == true)
            {
                arduinoCommunicationSender.SendMessageToSlaves("2");
                timePassed = DateTime.Now;
                isMessageSent = true;

                Debug.Log("Enviou a mensagem: " + player.isPlaying);
                Debug.Log("Playing without sound");
            }
            else
            {
                arduinoCommunicationSender.SendMessageToSlaves("1");
                timePassed = DateTime.Now;
                isMessageSent = true;

                Debug.Log("Enviou a mensagem: " + player.isPlaying);
                Debug.Log("Playing with sound");

            }

        }

        if ((DateTime.Now - timePassed).TotalSeconds >= masterDelay && isMessageSent && !isPlaying )
        {
            if (countPlayed != 0 && controlSound == true)
            {
                player.SetDirectAudioMute(0, true);
                player.Play();
                isMessageSent = false;
                isPlaying = true;
                Debug.Log("Play: " + player.isPlaying);
                countPlayed--;
            }
            else
            {
                player.SetDirectAudioMute(0, false);
                player.Play();
                isMessageSent = false;
                isPlaying = true;
                Debug.Log("Play: " + player.isPlaying);
                countPlayed = totalCount;
            }
        }

        if (player.isPlaying == false && prevIsPlaying == true)
        {
            Debug.Log("Over");
            Debug.Log((DateTime.Now - playStartTime).TotalSeconds);
            if ((DateTime.Now - playStartTime).TotalSeconds > 2)
            {
                isPlaying = false;
                Debug.Log("isPlaying = false");
            }
        }

        if (player.isPlaying == true && prevIsPlaying == false)
        {
            playStartTime = DateTime.Now;
            Debug.Log("Started");
        }

        prevIsPlaying = player.isPlaying;
    }
}