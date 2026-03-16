using UnityEngine;

public class PicoPointer : MonoBehaviour
{
    public float sensitivity = 1.0f;

    // We store the rotation so we can "clamp" it (prevent flipping)
    float rotX = 0f;
    float rotY = 0f;

    void Start()
    {
        // This keeps the mouse cursor in the middle of the game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1. Get the mouse movement (this is your Pico!)
        float moveX = Input.GetAxis("Mouse X") * sensitivity;
        float moveY = Input.GetAxis("Mouse Y") * sensitivity;

        // 2. Add to our current rotation
        rotY += moveX;
        rotX -= moveY;

        // 3. Prevent the gun from flipping over backwards
        rotX = Mathf.Clamp(rotX, -80f, 80f);

        // 4. APPLY ROTATION (Notice Z is 0 - This is your NO-ROLL fix!)
        transform.localRotation = Quaternion.Euler(rotX, rotY, 0);

        // 5. BUTTON LOGIC (Mouse Button 0 is Left Click)
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Fired!");
            // Trigger your muzzle flash or sound here
        }
    }
}