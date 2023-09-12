using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class DisplayController : MonoBehaviour
{
    public Vector2 newPivot;
    RectTransform rectTransform;


    private void OnEnable()
    {

        rectTransform = GetComponent<RectTransform>();

        DisplaySetup loadedData = LoadFromJsonFile<DisplaySetup>("display_data.json");
        newPivot = new Vector2(float.Parse(loadedData.VideoSettings.Pivot[0]), float.Parse(loadedData.VideoSettings.Pivot[1]));
        rectTransform.pivot = newPivot;
        

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
