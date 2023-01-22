using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the background game object for the parallax effect
public class Parallax : MonoBehaviour
{

    // This is the speed at which the background will move
    [SerializeField] private float scrollSpeed = 2.0f;
    // [SerializeField] private float spriteOffset1 = 0.03f;
    [SerializeField] private float spriteOffset = 0.03f;

    private float width;

    private GameObject camera;
    private GameObject rootObject;
    private GameObject[] childObject;


    // Start is called before the first frame update
    void Start()
    {
        // Set camera to the main camera
        camera = GameObject.Find("Main Camera");

        // Set rootObject to the object this script is attached to
        rootObject = this.gameObject;

        // Initialize the childObject array to the number of children the rootObject has and add them to the array
        InitializeArray();

        // Set width to the width of the background sprite
        width = childObject[0].GetComponent<SpriteRenderer>().bounds.size.x;
        // print out the width of the background sprite with the name of the background
        Debug.Log("Width of " + rootObject.name + " is " + width);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the background sprite to the left at the speed of scrollSpeed
        MoveBackground();
    }

    // This function is called to move the background sprites by looping through each childObject of the parent object
    void MoveBackground() {
        for (int i = 0; i < childObject.Length; i++)
        {
            childObject[i].transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

            // If the childObject right bound is off the cameras left bound then move the childObject to the previous childObject right bound
            if (childObject[i].GetComponent<SpriteRenderer>().bounds.max.x < camera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0, 0, 0)).x && i > 0)
            {
                // Set the position of childObject to the previous childObject right bound
                childObject[i].transform.position = new Vector2(childObject[i - 1].GetComponent<SpriteRenderer>().bounds.max.x + (width / 2) - spriteOffset, childObject[i].transform.position.y);
            } else if (childObject[i].GetComponent<SpriteRenderer>().bounds.max.x < camera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0, 0, 0)).x && i == 0){
                // Set the position of childObject to the last childObject right bound
                childObject[i].transform.position = new Vector2(childObject[childObject.Length - 1].GetComponent<SpriteRenderer>().bounds.max.x + (width / 2) - spriteOffset, childObject[i].transform.position.y);
            }
        }
    }

    void InitializeArray() {
        childObject = new GameObject[rootObject.transform.childCount];
        
        // For each child of the rootObject set childObject[i] to the child
        for (int i = 0; i < rootObject.transform.childCount; i++)
        {
            childObject[i] = rootObject.transform.GetChild(i).gameObject;
        }
    }
}
