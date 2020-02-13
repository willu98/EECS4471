using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightFore : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("5") || Input.GetKeyDown("6"))
        {
            anim.Play("rightFore");
        }
    }
}
