using UnityEngine;
using System.IO.Ports;

public class PicoMPUController : MonoBehaviour
{
    SerialPort serial;

    float yaw;
    float pitch;
    int fire;

    void Start()
    {
        try
        {
            serial = new SerialPort("COM3", 115200);
            serial.ReadTimeout = 1;
            serial.Open();

            Debug.Log("Serial connected");
        }
        catch
        {
            Debug.Log("Serial failed");
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
                    Debug.Log(data);
                }
            }
            catch
            {
                // ignore errors
            }
        }

        transform.localRotation = Quaternion.Euler(pitch, transform.localEulerAngles.y, 0);
    }

    void ParseData(string data)
    {
        string[] values = data.Split(',');

        if (values.Length == 3)
        {
            float.TryParse(values[0], out yaw);
            float.TryParse(values[1], out pitch);
            int.TryParse(values[2], out fire);

            if (fire == 1)
                Debug.Log("FIRE!");
        }
    }

    void OnApplicationQuit()
    {
        if (serial != null && serial.IsOpen)
            serial.Close();
    }
}