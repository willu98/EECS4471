using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    int camView = 0;
    GameObject ballObj;
    GameObject trajectory;
    GameObject[] targets = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {   
        ballObj = GameObject.Find("Projectile");

        for (int i = 0; i < 5; i++) {
            targets[i] = GameObject.Find("target(" + i + ")");
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (camView) {
            case 0:
                this.transform.position = new Vector3(0.4f, 19.5f, -52.28f);
                this.transform.LookAt(new Vector3(0.4f, 19.5f, 0f));
                break;
            case 1:
                this.transform.position = new Vector3(37.4f, 12.2f, -5.2f);
                this.transform.LookAt(new Vector3(0, 12.2f, -5.2f));
                break;
            case 2:
                this.transform.position = ballObj.transform.position;
                this.transform.LookAt(GameObject.Find("Trajectory").transform.position);
                break;
            default:

                this.transform.position = targets[camView - 3].transform.position;
                
                this.transform.LookAt(ballObj.transform.position);
                break;

        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            camView++;
            if (camView >= 8) {
                camView = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && camView > 0)
        {
            camView--;
        }
    }
}
