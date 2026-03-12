using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class HandTrackingUDP : MonoBehaviour
{
    UdpClient client;
    public int port = 5516;

    // Show received data in Inspector
    public string receivedData;

    void Start()
    {
        client = new UdpClient(port);
    }

    void Update()
    {
        if (client.Available > 0)
        {
            IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, port);
            byte[] data = client.Receive(ref anyIP);

            receivedData = Encoding.UTF8.GetString(data);
        }
    }
}