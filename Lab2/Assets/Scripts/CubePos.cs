using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePos : MonoBehaviour
{
    Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            this.transform.position = initialPos;
            

        }
    }
}
