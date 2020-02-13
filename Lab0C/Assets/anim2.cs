using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim2 : MonoBehaviour
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
        if (Input.GetKeyDown("3") || Input.GetKeyDown("5"))
        {
            anim.Play("anim2");
        }
    }
}
