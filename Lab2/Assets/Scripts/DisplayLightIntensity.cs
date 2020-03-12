using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLightIntensity : MonoBehaviour
{
    Text displayLightIntensity;
    public static float rLightIntensity = 1f;
    public static float wLightIntensity = 0f;
    public static float bLightIntensity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        displayLightIntensity = GetComponent<Text>();
    }

    public void adjustRed(float newIntensity)
    {
        rLightIntensity = newIntensity;
    }

    public void adjustBlue(float newIntensity)
    {
        bLightIntensity = newIntensity;
    }

    public void adjustWhite(float newIntensity)
    {
        wLightIntensity = newIntensity;
    }


    // Update is called once per frame
    void Update()
    {
        displayLightIntensity.text = "White Light Intensity: " + wLightIntensity + "\nRed Light Intensity: " + rLightIntensity + "\nBlue Light Intensity: " + bLightIntensity;
    }
}
