using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System;
using UnityEditor.PackageManager;

public class ArduinoCommunicationReceiver : MonoBehaviour
{
    SerialPort serialPort;
    Thread receiverThread;
    public string port;
    public int baudrate;
    public string dataReceived;
    public static LockFreeQueue<string> myQueue;
    public bool startReceiving = true;
    public bool printToConsole = false;
    public string data;

    void Start()
    {
        serialPort = new SerialPort(port, baudrate);
        serialPort.Open();

        myQueue = new LockFreeQueue<string>();
        receiverThread = new Thread(
            new ThreadStart(ReceiveData));
        receiverThread.IsBackground = true;
        receiverThread.Start();
    }

    private void ReceiveData()
    {
        while (startReceiving)
        {

            if (serialPort.IsOpen)
            {
                try
                {
                    string dataReceived = serialPort.ReadLine();
                    
                    myQueue.Enqueue(data);

                    if (printToConsole) { print(data); }

                }
                catch (Exception err)
                {
                    print(err.ToString());
                }
            }
        }
    }

    // returns the first item in the queue
    public string GetData()
    {
        if (myQueue.Empty()) return "";

        return myQueue.Dequeue();
    }

    // returns the last item in the queue
    // also clears the queue
    public string GetLastestData()
    {
        string result = "";
        string data = "";
        while ((data = GetData()) != "")
        {
            result = data;
        }

        return result;
    }

    // returns the last item in the queue
    // if it is newer than maxAge seconds
    public string GetLastestNewData(float maxAge)
    {
        //    if (GetCurrentTime() - timeLastDataReceived > maxAge)
        //        return "";
        //
        return GetLastestData();
    }

    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
