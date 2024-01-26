using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Iterate through each child of the parent object
        foreach (Transform child in transform)
        {
            // Move the child without affecting the parent
            child.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
}
