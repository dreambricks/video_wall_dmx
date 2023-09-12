
[System.Serializable]
public class VideoSettings
{
    private string filename;
    private string displayQuantity;
    private string position;
    private string[] videoSize;
    private string[] pivot;

    public VideoSettings()
    {
    }

    public VideoSettings(string filename, string position, string[] videoSize, string[] pivot, string displayQuantity)
    {
        this.filename = filename;
        this.position = position;
        this.videoSize = videoSize;
        this.pivot = pivot;
        this.displayQuantity = displayQuantity;
       
    }

    public string Filename { get => filename; set => filename = value; }
    public string Position { get => position; set => position = value; }
    public string[] VideoSize { get => videoSize; set => videoSize = value; }
    public string[] Pivot { get => pivot; set => pivot = value; }
    public string DisplayQuantity { get => displayQuantity; set => displayQuantity = value; }
}
