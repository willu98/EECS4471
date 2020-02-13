using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    public Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("2") || Input.GetKeyDown("5"))
        {
            anima.Play("Parent1anim");
        }
    }


}
