using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLauncher : MonoBehaviour
{
    private float speed = 0.5f;
    private float X;

    private bool isLaunching = false;
    //determines if the camera is rotating or moving
    private bool isTranslating = true;
    private bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isLaunching = true;
            isTranslating = false;
            isRotating = false;
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            isLaunching = false;
            isTranslating = true;
            isRotating = false;
        }

        //switching between transl;ation and rotation states for the camera
        if (Input.GetKey(KeyCode.T) && !isTranslating)
        {
            isTranslating = true;
            isRotating = false;
        }
        else if (Input.GetKey(KeyCode.R) && isTranslating && !isLaunching)
        {
            isTranslating = false;
            isRotating = true;
        }

        //if the camera is in translation mode
        if (isTranslating)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 position = this.transform.position;
                position.z += 0.05f;
                this.transform.position = position;
            }

            if (Input.GetKey(KeyCode.S))
            {
                Vector3 position = this.transform.position;
                position.z -= 0.05f;
                this.transform.position = position;
            }

            if (Input.GetKey(KeyCode.A))
            {
                Vector3 position = this.transform.position;
                position.x -= 0.05f;
                this.transform.position = position;
            }

            if (Input.GetKey(KeyCode.D))
            {
                Vector3 position = this.transform.position;
                position.x += 0.05f;
                this.transform.position = position;
            }
        }
        //if the camera is in rotation mode
        else if(isRotating)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.RotateAround(this.transform.position, Vector3.down, 0.1f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.RotateAround(this.transform.position, Vector3.up, 0.1f);
            }
        }
    }
}
