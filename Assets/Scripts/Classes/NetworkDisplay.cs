
[System.Serializable]
public class NetworkDisplay
{
    private string port;
    private string broadCastAddress;
    private string masterOrSlave;
    private string masterExtraDelay;

    public NetworkDisplay()
    {
    }

    public NetworkDisplay(string port, string broadCastAddress, string masterOrSlave, string masterExtraDelay)
    {
        this.port = port;
        this.broadCastAddress = broadCastAddress;
        this.masterOrSlave = masterOrSlave;
        this.masterExtraDelay = masterExtraDelay;
    }

    public string Port { get => port; set => port = value; }
    public string BroadCastAddress { get => broadCastAddress; set => broadCastAddress = value; }
    public string MasterOrSlave { get => masterOrSlave; set => masterOrSlave = value; }
    public string MasterExtraDelay { get => masterExtraDelay; set => masterExtraDelay = value; }
}
