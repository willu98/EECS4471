using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //RESET BUTTON
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.gameObject.SetActive(true);
        }

        //LAUNCH BUTTON
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.SetActive(false);
        }
    }
}