using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);
        Vector2 position = transform.position;  //The first word before the variable name, Vector2, is the type of the variable. Types tell the computer what kind of data you want to store, so it can get the right amount of space in memory. A Vector2 is a data type that stores two numbers. Remember the Transform values in the Inspector that use x for the horizontal position, y for the vertical position and z for the depth. Those 3 numbers form a coordinate,. Because this game is 2D, you don’t need to store the z-axis position, so you can use a Vector2 here to only store the x and y positions.
        position.x = position.x + 0.1f * horizontal; //Here you are accessing the x value, which is the horizontal position. To move your GameObject slightly to the right, you have added 0.1 to the x value and stored the result back into x. 
        transform.position = position;  //In the third line, you stored that new Position inside the position of the Transform: Before this line of code, you were only modifying a copy, like doing math on a side sheet of paper. Now that you have the new result, you need to give it back to the Transform component so that it actually knows to move the GameObject 0.1 units to the right! The computer executes this function for every new frame, so your object will move 0.1 unit to the right in each new frame compared to the last one. This gives the illusion of the GameObject continuously moving to the right.
    }
}
