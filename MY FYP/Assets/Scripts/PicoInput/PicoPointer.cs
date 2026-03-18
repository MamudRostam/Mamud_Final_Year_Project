using UnityEngine;

public class PicoPointer : MonoBehaviour
{
    public float sensitivity = 1.0f;

 
    float rotX = 0f;
    float rotY = 0f;

    void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
      
        float moveX = Input.GetAxis("Mouse X") * sensitivity;
        float moveY = Input.GetAxis("Mouse Y") * sensitivity;

        
        rotY += moveX;
        rotX -= moveY;
     
        rotX = Mathf.Clamp(rotX, -80f, 80f);
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            rotX = 0f;
            rotY = 0f;
        }

        transform.localRotation = Quaternion.Euler(rotX, rotY, 0);
    }
}