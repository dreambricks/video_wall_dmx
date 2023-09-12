using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class GameHandler : MonoBehaviour
{

    private DisplaySetup displaySetup;
    public SetupUI setupUI;
    public VideoPlayer player;
    

    private bool ativo = false;
    void Awake()
    {

        setupUI.gameObject.SetActive(false);
        player.gameObject.SetActive(false);

        DisplaySetup loadedData = LoadFromJsonFile<DisplaySetup>("display_data.json");
        Debug.Log(loadedData);
        if (loadedData == null)
        {
            setupUI.gameObject.SetActive(true);
        }
        else
        {
            player.gameObject.SetActive(true);
        }

    }

    void Update()
    {
        OpenMenuSettings();
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

    private void OpenMenuSettings()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ativo = !ativo;
            setupUI.gameObject.SetActive(ativo);
        }
    }
}
