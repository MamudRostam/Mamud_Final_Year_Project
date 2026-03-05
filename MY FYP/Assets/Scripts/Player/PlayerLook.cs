using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivty = 30f;
    public float ySensitivity = 30f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        xRotation = cam.transform.localEulerAngles.x;

        if (xRotation > 180f)
            xRotation = 360;
    }

    public void ProcessLook(Vector2 input)
    {
        if (Time.timeScale == 0f) return;
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivty);
    }
}
