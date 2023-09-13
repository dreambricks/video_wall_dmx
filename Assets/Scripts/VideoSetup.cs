using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class VideoSetup : MonoBehaviour
{
    private VideoPlayer player;

    private VideoManagerSender videoManagerSender;
    private VideoManagerReceiver videoManagerReceiver;

    public ArduinoCommunicationReceiver arduinoCommunicationReceiver;
    public ArduinoCommunicationSender arduinoCommunicationSender;

    private void OnEnable()
    {
        player = GetComponent<VideoPlayer>();
       
        DisplaySetup loadedData = SaveManager.LoadFromJsonFile<DisplaySetup>("display_data.json");
        if (loadedData == null || loadedData.VideoSettings.Filename == "" || loadedData.VideoSettings.Filename == null)
        {
            player.url = "C:\\Users\\julio\\Documents\\DB\\Unity\\video_wall\\Assets\\Video\\dgo.mp4";
        }else
        {
            player.url = loadedData.VideoSettings.Filename;
        }

        videoManagerSender = GetComponent<VideoManagerSender>();
        videoManagerReceiver = GetComponent<VideoManagerReceiver>();

        string masterOrSlave = loadedData.NetworkDisplay.MasterOrSlave;
        if (masterOrSlave == "Slave")
        {
            videoManagerSender.enabled = false;
            arduinoCommunicationReceiver.gameObject.SetActive(true);
        }
        else
        {
            videoManagerReceiver.enabled = false;
            arduinoCommunicationSender.gameObject.SetActive(true);
        }
    }
}
