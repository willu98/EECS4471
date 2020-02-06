using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraMove : MonoBehaviour
{
    public float speed = 0.5f;
    private float X;
    private float Y;

    //determines if the camera is rotating or moving
    public bool isTranslating = true;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {


        

        //switching between transl;ation and rotation states for the camera
        if (Input.GetKey(KeyCode.T) && !isTranslating)
        {
            isTranslating = true;
        }
        else if (Input.GetKey(KeyCode.R) && isTranslating) {
            isTranslating = false;
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

            if (Input.GetKey(KeyCode.X))
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
        else {
            
            this.transform.Rotate(0, Input.GetAxis("Horizontal") * speed , 0);
            this.transform.Rotate(-Input.GetAxis("Vertical") * speed, 0, 0);
            
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
    }
}
