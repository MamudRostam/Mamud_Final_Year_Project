using UnityEngine;
using System.IO.Ports;

public class PicoMPUController : MonoBehaviour
{
    SerialPort serial;

    float yaw;
    float pitch;
    int fire;

    // Adjust these to control sensitivity
    public float yawSensitivity = 2.0f;   // left/right
    public float pitchSensitivity = 2.0f; // up/down

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
                }
            }
            catch
            {
                // ignore errors
            }
        }

        // Apply sensitivity
        float clampedPitch = Mathf.Clamp(-pitch * pitchSensitivity, -80f, 80f);
        float adjustedYaw = -yaw * yawSensitivity;

        transform.localRotation =
            Quaternion.Euler(clampedPitch, adjustedYaw, 0);
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