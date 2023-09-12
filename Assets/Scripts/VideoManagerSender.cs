using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManagerSender : MonoBehaviour
{
    private VideoPlayer player;
    private float masterDelay;

    public ArduinoCommunicationSender arduinoCommunicationSender;
   

    void Start()
    {
        player = GetComponent<VideoPlayer>();
        DisplaySetup loadedData = SaveManager.LoadFromJsonFile<DisplaySetup>("display_data.json");
        masterDelay = float.Parse(loadedData.NetworkDisplay.MasterExtraDelay);

    }

    // Update is called once per frame
    void Update()
    {
        PlayVideo();
    }

    void PlayVideo()
    {
        
        if (player.isPlaying == false)
        {
            //player.Play();
            StartCoroutine(PlayCoroutine());
        }
        
    }
    
    IEnumerator PlayCoroutine()
    {
        for(int i = 10; i > 0; i--)
        {
            // send numbers from 10 to 1 by UDP
            
            arduinoCommunicationSender.SendMessageToSlaves("1");
            yield return new WaitForSeconds(0.01F);
        }
        // recommended 15ms to 30 ms
        float delay = masterDelay;
        yield return new WaitForSeconds(delay);
        Debug.Log("Master delay: " + delay);
        player.Play();

        //yield WaitForSeconds(0);
    }
        
}
