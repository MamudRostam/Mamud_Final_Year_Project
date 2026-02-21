using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class PicoInput : MonoBehaviour
{
    public int port = 5005;
    public Transform cameraPivot;

    UdpClient client;
    Thread receiveThread;

    float yaw;
    float pitch;


    void Start()
    {
        client = new UdpClient(port);
        receiveThread = new Thread(ReceiveLoop);
        receiveThread.IsBackground = true;
        receiveThread.Start();

        Debug.Log("Listening for Pico on port " + port);
    }

    void ReceiveLoop()
    {
        IPEndPoint ep = new IPEndPoint(IPAddress.Any, port);

        while (true)
        {
            try
            {
                byte[] data = client.Receive(ref ep);
                string message = Encoding.UTF8.GetString(data);

                Debug.Log("Received: " + message);

                string[] values = message.Split(',');

                yaw = float.Parse(values[0]);
                pitch = float.Parse(values[1]);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }

    void Update()
    {
        if (cameraPivot == null) return;

        // Sensitivity
        float yawSens = 0.2f;
        float pitchSens = 0.2f;

        float y = yaw * yawSens;
        float p = pitch * pitchSens;

        // Clamp pitch like a real camera
        p = Mathf.Clamp(p, -85f, 85f);

        cameraPivot.localRotation = Quaternion.Euler(-p, y, 0f);
    }

    void OnApplicationQuit()
    {
        receiveThread?.Abort();
        client?.Close();
    }
}