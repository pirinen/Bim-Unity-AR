using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VDCameraToggler : MonoBehaviour
{
    [SerializeField]
    Camera[] CameraArray;

    [SerializeField]
    int CurrentCamera = 0;

    [SerializeField]
    float KeyDelay = 0.4f;
    [SerializeField]
    float LastKeyInput = 0.0f;

    // Use this for initialization
    void Start()
    {
        if (CameraArray.Length < 1)
        {
            Debug.Log("CameraToggler only has one camera and is not needed. The toggler has been disabled.");
            this.gameObject.active = false;

            // Ensure if there is 1 camera attached that it is enabled
            if (CameraArray.Length == 1)
                CameraArray[0].gameObject.active = true;
        }
        else
        {
            // Disable all cameras except for the startup camera
            for (int i = 0; i < CameraArray.Length; i++)
            {
                Debug.Log("CameraToggler");
                if (CurrentCamera == i)
                    CameraArray[i].gameObject.active = true;
                else
                    CameraArray[i].gameObject.active = false;
            }
        }
    }
    void Update()
    {
        // Check for user input only if the last input was more than x seconds ago
        // (0.4 seconds is generally enough time to ensure the key capture doesn't happen more than once
        // on a single key press

        if (Input.GetKey(KeyCode.F) && LastKeyInput + KeyDelay <= Time.realtimeSinceStartup) // Can be used instead of the below
        //if (Input.GetButton("Switch Camera") && LastKeyInput + KeyDelay <= Time.realtimeSinceStartup) // Can be used instead of the above
        {
            if (CurrentCamera + 1 < CameraArray.Length)
            {
                // Disable current camera and enable next camera
                CameraArray[CurrentCamera].gameObject.active = false;
                CurrentCamera++;
                CameraArray[CurrentCamera].gameObject.active = true;
            }
            else
            {
                // Disable current camera and enable first camera
                CameraArray[CurrentCamera].gameObject.active = false;
                CurrentCamera = 0;
                CameraArray[CurrentCamera].gameObject.active = true;
            }

            LastKeyInput = Time.realtimeSinceStartup;
        }
    }
}
