using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class del : MonoBehaviour
{
    Component[] gameObjects;
    List<Component> gameObjectsList = new List<Component>();
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        // foreach (Transform child in transform)
        // {
        //     //child is your child transform
        //     gameObjects.Add(child);
        // }

        gameObjects = this.GetComponentsInChildren<Transform>();

        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i].name == "Plane" ||
                gameObjects[i].name == "Sphere" |
                gameObjects[i].name == "Cube")
            {
                gameObjectsList.Add(gameObjects[i]);
            }
        }

        index = 0;
        Debug.Log(gameObjectsList.Count);
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < gameObjectsList.Count; i++)
        {
            gameObjectsList[i].gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

            if (i == index)
            {
                gameObjectsList[i].gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            index++;
            if (index > gameObjectsList.Count - 1)
            {
                index = 0;
            }
        }

        Debug.Log(gameObjectsList[index].name + " " + index);
    }
}
