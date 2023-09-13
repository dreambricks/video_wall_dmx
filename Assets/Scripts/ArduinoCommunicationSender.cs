using UnityEngine;
using System.IO.Ports;

public class ArduinoCommunicationSender : MonoBehaviour
{
    public SerialPort serialPort;
    public string port;
    public int baudrate;

    void Start()
    {
        serialPort = new SerialPort(port, baudrate);
        serialPort.Open();
    }

    public void SendMessageToSlaves(string message)
    {
        if (serialPort.IsOpen)
        {
            try
            {
                // Send a message to the Arduino
                serialPort.WriteLine(message);
            }
            catch (System.Exception)
            {
                // Handle any errors or exceptions.
            }
        }
    }

    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
