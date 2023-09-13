
[System.Serializable]
public class NetworkDisplay
{
    private string masterOrSlave;
    private string masterExtraDelay;

    private string serialPort;
    private int baudrate;

    public NetworkDisplay()
    {
    }

    public NetworkDisplay(string masterOrSlave, string masterExtraDelay, string serialPort, int baudrate)
    {
        this.masterOrSlave = masterOrSlave;
        this.masterExtraDelay = masterExtraDelay;
        this.serialPort = serialPort;
        this.baudrate = baudrate;
    }


    public string MasterOrSlave { get => masterOrSlave; set => masterOrSlave = value; }
    public string MasterExtraDelay { get => masterExtraDelay; set => masterExtraDelay = value; }
    public string SerialPort { get => serialPort; set => serialPort = value; }
    public int Baudrate { get => baudrate; set => baudrate = value; }
}
