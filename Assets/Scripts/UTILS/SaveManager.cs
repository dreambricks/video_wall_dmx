using UnityEngine;
using Newtonsoft.Json; // Importa a biblioteca JSON.NET
using System.IO;


public class SaveManager : MonoBehaviour
{

    private void Start()
    {
    }

    public static void SaveToJsonFile<T>(T data, string fileName)
    {
        string jsonData = JsonConvert.SerializeObject(data); // Converte o objeto para uma string JSON

        // Define o caminho do arquivo onde queremos salvar
        string path = Path.Combine(Application.streamingAssetsPath, fileName);

        // Salva o arquivo em disco
        File.WriteAllText(path, jsonData);

        Debug.Log("Objeto salvo como JSON em: " + path);
    }

    public static T LoadFromJsonFile<T>(string fileName)
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
            Debug.LogWarning("Arquivo n�o encontrado: " + path);
            return default(T);
        }
    }
}
