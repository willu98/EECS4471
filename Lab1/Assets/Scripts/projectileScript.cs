using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    private float force = 1.0f;
    private float torque = 0.0f;
    private int score = 0;

    //original position and rotattion
    private Quaternion origRotation;

    private Rigidbody rb;
    public GameObject trajectoryObj;

    // Start is called before the first frame update
    void Start()
    {
        origRotation = this.transform.rotation;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.F)) {
            force -= 5f;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            force += 5f;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.T))
        {
            torque -= 3f;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            torque += 3f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(this.transform.position, Vector3.left, 0.1f);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            transform.RotateAround(this.transform.position, Vector3.right, 0.1f);

        }

        //RESET BUTTON
        if (Input.GetKeyDown(KeyCode.Q))
        {

            rb.useGravity = false;
            rb.isKinematic = true;
            this.transform.position = this.transform.parent.transform.position + new Vector3(0,5, 0);
            this.transform.rotation = origRotation;
            force = 0;
            torque = 0;
            trajectoryObj.SetActive(true);

        }

        //LAUNCH BUTTON
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
            rb.AddTorque(Vector3.right * torque);
            trajectoryObj.SetActive(false);
        }
       // Debug.Log("FORCE: " + force);
        //Debug.Log("TORQUE: " + torque);
    }

}
