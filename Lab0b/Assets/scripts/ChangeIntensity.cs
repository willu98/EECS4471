using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIntensity : MonoBehaviour
{
    public Light lt;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            lt.intensity += 0.05f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            lt.intensity -= 0.05f;
        }
    }
}
