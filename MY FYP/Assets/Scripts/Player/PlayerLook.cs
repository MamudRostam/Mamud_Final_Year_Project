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


        if (Input.GetKeyDown(KeyCode.R))
        {
            xRotation = 0f;
            cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        }
    }
}