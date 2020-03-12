using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGrav : MonoBehaviour
{
    Text displayGrav;
    public bool isGrav = false;
    public static float grav = 0f;
    private string gravOn = "OFF";
    // Start is called before the first frame update
    void Start()
    {
        displayGrav = GetComponent<Text>();
    }

    public void adjustGravity(float newGrav)
    {
        grav = newGrav;
    }

    public void toggleGrav()
    {
        isGrav = !isGrav;
        if (isGrav)
        {
            gravOn = "ON";
        }
        else {
            gravOn = "OFF";
        }
    }

    // Update is called once per frame
    void Update()
    {
        displayGrav.text = "GRAVITY CONSTANT: " + grav + "\nGravity: " + gravOn;
    }
}
