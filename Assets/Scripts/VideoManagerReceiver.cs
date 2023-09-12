using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManagerReceiver : MonoBehaviour
{
    private VideoPlayer player;
    public ArduinoCommunicationReceiver arduinoCommunicationReceiver;

    void Start()
    {
        player= GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayVideo();
    }

    void PlayVideo()
    {
        //string data = udpReceiver.GetLastestData();
        string data = arduinoCommunicationReceiver.GetLastestNewData(1.0f);// don't get data that is older than 1 second
        int value;
        if (int.TryParse(data, out value))
        {
            if (value == 1)
            {
                arduinoCommunicationReceiver.GetLastestData();
                player.Play();
            }
        }
    }
}
