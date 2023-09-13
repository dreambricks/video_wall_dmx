using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class GameHandler : MonoBehaviour
{

    public SetupUI setupUI;
    public VideoPlayer player;

    [SerializeField] private GameObject render;
    
    private bool ativo = false;
    void Awake()
    {
        player.gameObject.SetActive(false);
        render.SetActive(false);
        setupUI.gameObject.SetActive(false);

        DisplaySetup loadedData = LoadFromJsonFile<DisplaySetup>("display_data.json");

        if (loadedData == null)
        {
            setupUI.gameObject.SetActive(true);
        }
        else
        {
            render.SetActive(true);
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
            return default(T);
        }
    }

    private void OpenMenuSettings()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ativo = !ativo;
            setupUI.gameObject.SetActive(ativo);
            render.SetActive(!ativo);
            player.gameObject.SetActive(!ativo);
        }
    }

}
