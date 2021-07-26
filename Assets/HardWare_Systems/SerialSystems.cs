using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SerialSystems : MonoBehaviour
{
    public bool IsSetting => port != null && port.IsOpen;
    [SerializeField, Range(1,100)]
    public int COM;

    [SerializeField, Range(1, 1000000)]
    public int BaudRate;

    SerialPort port;

    public string init()
    {
        try
        {

            if (port.IsOpen)
            {
                port.Close();
                port.Dispose();
            }

            port = new SerialPort()
            {
                PortName = "COM" + COM,
                BaudRate = BaudRate,
                NewLine = "\n",
                ReadTimeout = 10,
                WriteTimeout = 10,
                Parity = Parity.None,
            };

            port.Open();
            while (!port.IsOpen) ;
            return "";
        }
        catch (Exception e)
        {
            return e.Message;
        }

    }

    public string ReadLine() => port.ReadLine();
    public void Write(string s) => port.Write(s);
    public void WriteLine(string s) => port.WriteLine(s);

    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit");
        port.Close();
        port.Dispose();
    }

}
