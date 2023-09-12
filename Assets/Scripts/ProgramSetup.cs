using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

public class ProgramSetup : MonoBehaviour
{

    public DisplaySetup displaySetup;
    public GameObject player;
    public SetupUI setupUI;

    public InputField port;
    public InputField broadCastAddress;
    public Dropdown masterOrSlave;
    public InputField masterExtraDelay;

    public InputField fileName;
    public InputField displayQuantity;
    public Dropdown position;
    public InputField videoSizeW;
    public InputField videoSizeH;
    public InputField pivotX;
    public InputField pivotY;

    public void SaveSettings()
    {
        DisplaySetup displaySetup = new DisplaySetup();
        NetworkDisplay networkDisplay = new NetworkDisplay();
        VideoSettings videoSettings = new VideoSettings();

        networkDisplay.Port = port.text;
        networkDisplay.BroadCastAddress = broadCastAddress.text;
        int selectedIndex = masterOrSlave.value;
        networkDisplay.MasterOrSlave = masterOrSlave.options[selectedIndex].text;
        networkDisplay.MasterExtraDelay = masterExtraDelay.text;
        displaySetup.NetworkDisplay= networkDisplay;

        videoSettings.Filename= fileName.text;
        videoSettings.DisplayQuantity = displayQuantity.text;
        int positionIndex = position.value;
        videoSettings.Position = position.options[positionIndex].text;
        videoSettings.VideoSize = new string[2];
        videoSettings.VideoSize[0] = videoSizeW.text;
        videoSettings.VideoSize[1] = videoSizeH.text;
        videoSettings.Pivot = new string[2];
        videoSettings.Pivot[0] = pivotX.text;
        videoSettings.Pivot[1] = pivotY.text;
        displaySetup.VideoSettings= videoSettings;

        SaveToJsonFile(displaySetup, "display_data.json");


        player.gameObject.SetActive(true);  

        setupUI.gameObject.SetActive(false);
    }


    private void SaveToJsonFile<T>(T data, string fileName)
    {
        string jsonData = JsonConvert.SerializeObject(data); // Converte o objeto para uma string JSON

        // Define o caminho do arquivo onde queremos salvar
        string path = Path.Combine(Application.streamingAssetsPath, fileName);

        // Salva o arquivo em disco
        File.WriteAllText(path, jsonData);

        Debug.Log("Objeto salvo como JSON em: " + path);
    }


}
