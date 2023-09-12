using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class VideoSetup : MonoBehaviour
{
    private VideoPlayer player;

    private VideoManagerSender videoManagerSender;
    private VideoManagerReceiver videoManagerReceiver;
    private DisplaySetup displaySetup;

    public ArduinoCommunicationReceiver arduinoCommunicationReceiver;
    public ArduinoCommunicationSender arduinoCommunicationSender;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.url = "C:\\Users\\julio\\Documents\\DB\\Unity\\video_wall\\Assets\\Video\\dgo.mp4";
        //DisplaySetup loadedData = SaveManager.LoadFromJsonFile<DisplaySetup>("display_data.json");
        //player.url = loadedData.VideoSettings.Filename;
    }

    void Awake()
    {
        videoManagerSender = GetComponent<VideoManagerSender>();
        videoManagerReceiver = GetComponent<VideoManagerReceiver>();

        DisplaySetup loadedData = LoadFromJsonFile<DisplaySetup>("display_data.json");

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

    private T LoadFromJsonFile<T>(string fileName)
    {
        // Define o caminho do arquivo onde queremos carregar
        string path = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(jsonData); // Desserializa a string JSON para o objeto
        }
        else
        {
            Debug.LogWarning("Arquivo não encontrado: " + path);
            return default(T);
        }
    }
}
