
[System.Serializable]
public class VideoSettings
{
    private string filename;
    private string displayQuantity;
    private string position;
    private string[] videoSize;
    private string[] pivot;
    private string soundControl;
    private string countPlayed;

    public VideoSettings()
    {
    }

    public VideoSettings(string filename, string position, string[] videoSize, string[] pivot, string displayQuantity, string soundControl, string countPlayed)
    {
        this.filename = filename;
        this.position = position;
        this.videoSize = videoSize;
        this.pivot = pivot;
        this.displayQuantity = displayQuantity;
        this.soundControl = soundControl;
        this.countPlayed = countPlayed;
    }

    public string Filename { get => filename; set => filename = value; }
    public string Position { get => position; set => position = value; }
    public string[] VideoSize { get => videoSize; set => videoSize = value; }
    public string[] Pivot { get => pivot; set => pivot = value; }
    public string DisplayQuantity { get => displayQuantity; set => displayQuantity = value; }
    public string SoundControl { get => soundControl; set => soundControl = value; }
    public string CountPlayed { get => countPlayed; set => countPlayed = value; }
}
