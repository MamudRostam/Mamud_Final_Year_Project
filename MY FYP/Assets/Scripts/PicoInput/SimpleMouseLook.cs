using UnityEngine;

public class SimpleMouseLook : MonoBehaviour
{
    void Update()
    {
        // This will now automatically respond to your Pico movement!
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        transform.Rotate(-v, h, 0);
    }
}