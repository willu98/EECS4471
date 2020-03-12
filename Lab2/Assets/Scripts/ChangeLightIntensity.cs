using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightIntensity : MonoBehaviour
{
    Light lt;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();

    }
    public void adjuastIntensity(float newIntensity)
    {
        lt.intensity = newIntensity;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
