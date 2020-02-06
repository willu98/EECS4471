using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDelObj : MonoBehaviour
{
    //gameobject used for spawning prefabs
    public GameObject myPrefab;

    //array for maintaining all of the child members of the empty game object
    Component[] gameObjects;

    //list for the game objects
    List<Component> gameObjectsList = new List<Component>();


    //the current index of the sphere, will be indicated by a color change/material change
    int currIndex;

    // Start is called before the first frame update
    void Start()
    {
        //init to 0
        currIndex = 0;

        reInstantiate();
    }

    // Update is called once per frame
    void Update()
    {
        //adding new game objects, spawning prefab sphere with random location
        if (Input.GetKeyDown(KeyCode.N))
        {
            //instantiating the new prefab
            GameObject tmp = Instantiate(gameObjectsList[currIndex].gameObject, new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f)), Quaternion.identity);

            //allows for the spawned prefabs to be a child member of the empty game object
            tmp.transform.parent = transform;

            reInstantiate();

        }


        //if s key clicked, switch
        if (Input.GetKeyDown(KeyCode.S)) {
            //if at end of gameobj array then go back to start, otherwise continue to iterate
            currIndex = currIndex == gameObjectsList.Count - 1 ? 0 : currIndex + 1;
        }

        //if s key clicked, switch
        if (Input.GetKeyDown(KeyCode.K) && gameObjectsList.Count > 1)
        {
            //gameObjectsList.Remove()
            //removing game object
            Destroy(gameObjectsList[currIndex].gameObject);
            gameObjectsList.RemoveAt(currIndex);


            if (currIndex != 0) {
                currIndex--;
            }

        }

        //iterating through all objects to highlight the onen that is currently being hovered over
        for (int i = 0; i < gameObjectsList.Count; i++) {

            //set all to white
            gameObjectsList[i].gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);


            //set current one to red
            if (i == currIndex)
            {
                gameObjectsList[i].gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
        }

    }


    //this method reinstantiates the array and list of game objects, and is called when changes are made
    //either on 'k' or 'n' clicks
    void reInstantiate() {
        gameObjects = this.GetComponentsInChildren<Transform>();
        gameObjectsList.Clear();
        for (int i = 1; i < gameObjects.Length; i++)
        {

            gameObjectsList.Add(gameObjects[i]);


        }
    }
}
