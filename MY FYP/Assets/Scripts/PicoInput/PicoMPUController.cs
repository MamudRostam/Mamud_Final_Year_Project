using UnityEngine;
using System.IO.Ports;

public class PicoMPUController : MonoBehaviour
{
    SerialPort serial;

    float yaw;
    float pitch;
    int fire;

    public float sensitivity = 1.5f;   // adjust in inspector

    void Start()
    {
        string[] ports = SerialPort.GetPortNames();

        foreach (string port in ports)
        {
            try
            {
                serial = new SerialPort(port, 115200);
                serial.ReadTimeout = 1;
                serial.Open();

                Debug.Log("Connected to " + port);
                break;
            }
            catch
            {
                Debug.Log("Failed on " + port);
            }
        }

        if (serial == null || !serial.IsOpen)
        {
            Debug.Log("No serial ports connected");
        }
    }

    void Update()
    {
        if (serial != null && serial.IsOpen)
        {
            try
            {
                while (serial.BytesToRead > 0)
                {
                    string data = serial.ReadLine();
                    ParseData(data);
                }
            }
            catch { }
        }

        // Small drift deadzone
        if (Mathf.Abs(yaw) < 0.15f) yaw = 0;
        if (Mathf.Abs(pitch) < 0.15f) pitch = 0;

        transform.localRotation =
            Quaternion.Euler(-pitch * sensitivity, -yaw * sensitivity, 0);
    }

    void ParseData(string data)
    {
        string[] values = data.Split(',');

        if (values.Length == 3)
        {
            float.TryParse(values[0], out yaw);
            float.TryParse(values[1], out pitch);
            int.TryParse(values[2], out fire);
        }
    }

    void OnApplicationQuit()
    {
        if (serial != null && serial.IsOpen)
            serial.Close();
    }
}