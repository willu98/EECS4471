using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public float globalGravity;
    public bool displayUI;

    private bool hasGravity = false;
    private bool isKin = false;
    private bool isWhite;
    private bool canRemove;

    public GameObject prefab;
    public GameObject canvasUI;
    public GameObject colorBtn;

    GameObject lCtrlGameObj;
    GameObject rCtrlGameObj;

    public Material noPok;

    InputDevice leftController;
    InputDevice rightController;

    // Start is called before the first frame update
    void Start()
    {
        //setting global gravity to 0
        globalGravity = 0f;
        displayUI = true;

        isWhite = true;
        canRemove = false;

        //getting left and right controller
        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDevices.GetDevices(inputDevices);
        this.leftController = inputDevices[1];
        this.rightController = inputDevices[2];        
        List<InputFeatureUsage> list = new List<InputFeatureUsage>();
        leftController.TryGetFeatureUsages(list);

        lCtrlGameObj = GameObject.Find("LeftHand Controller");
        rCtrlGameObj = GameObject.Find("RightHand Controller");
    }

    public void AddObject()
    {
        //instantiating a new game obj
        GameObject temp = Instantiate(prefab);
        temp.transform.SetParent(null);
        temp.transform.position = new Vector3(
            Random.Range(-15f, 15f),
            Random.Range(-1f, 12f),
            Random.Range(-15f, 15f));
        temp.transform.RotateAround(Vector3.up, Random.Range(0f, 90f));
        temp.transform.RotateAround(Vector3.right, Random.Range(0f, 90f));
        temp.transform.RotateAround(Vector3.forward, Random.Range(0f, 90f));

        temp.GetComponent<Rigidbody>().useGravity = hasGravity;
        temp.GetComponent<Rigidbody>().mass = Random.Range(1f, 3f);

    }

    //adjusting the gravity
    public void adjustGravity(float newGrav)
    {
        globalGravity = newGrav;
    }

    //toggling the gravity
    public void toggleGrav() {
        hasGravity = !hasGravity;
    }

    public void ChangeColor() {
        isWhite = !isWhite;
        
    }


    public void ToggleRemove()
    {
        canRemove = !canRemove;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            displayUI = !displayUI;
            canvasUI.SetActive(displayUI);
        }

        GameObject[] temp = GameObject.FindGameObjectsWithTag("NewCube");

        if (Input.GetKeyDown(KeyCode.K))
        {
            isKin = !isKin;
        }

        ///changing gravity vakue as needed
        foreach (GameObject i in temp) {
            i.GetComponent<Rigidbody>().useGravity = hasGravity;
            i.GetComponent<Rigidbody>().isKinematic = isKin;
        }

        //changing gravity value
        Physics.gravity = new Vector3(0f, -1f * globalGravity, 0f);

        //checking for left input
        if (this.leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool lTriggerValue) && lTriggerValue) {
            hasGravity = true;
        }


        //checking for right input
        if (this.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool rTriggerValue) && rTriggerValue)
        {
            foreach (GameObject i in temp)
            {
                i.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 1f, 0f), ForceMode.Impulse);
            }
        }

        if (Physics.Raycast(lCtrlGameObj.transform.position, lCtrlGameObj.transform.forward, out RaycastHit hit) && hit.transform.tag == "NewCube"){
            if (this.leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool lTrigValue) && lTrigValue) {
                var current = hit.transform;
                var currentRenderer = current.GetComponent<Renderer>();

                if (isWhite){
                    currentRenderer.material.SetColor("_Color", Color.white);
                }
                else{
                    currentRenderer.material.SetColor("_Color", Color.black);
                }                 
            }

        }


        if (Physics.Raycast(rCtrlGameObj.transform.position, rCtrlGameObj.transform.forward, out RaycastHit hit2) && hit2.transform.tag == "NewCube")
        {
            if (this.rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool rTrigValue) && rTrigValue && !canRemove)
            {
                Destroy(hit2.transform.gameObject);
            }
        }

    }
}
