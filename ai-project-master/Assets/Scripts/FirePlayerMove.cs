using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirePlayerMove : MonoBehaviour
{

    private int[] dx = { 1, 0, -1, 0 };
    private int[] dy = { 0, 1, 0, -1 };
    private int count = 0;
    private int dir = 2;
    private int NextDir = -1;
    private Vector3 oldPosition;
    public GameObject Trace;
    public Transform Container;
    // Use this for initialization
    void Start()
    {
        oldPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        count = count % 20;
        if (count == 0) Instantiate(Trace, new Vector2(transform.position.x, transform.position.y), Quaternion.identity, Container);
        //Debug.Log(transform.position.x + " " + transform.position.y + " " + count);
        if (Input.GetKeyDown(KeyCode.UpArrow) && dir != 3)    NextDir = 1;
        if (Input.GetKeyDown(KeyCode.RightArrow) && dir != 2) NextDir = 0;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && dir != 0)  NextDir = 2;
        if (Input.GetKeyDown(KeyCode.DownArrow) && dir != 1)  NextDir = 3;

        if (NextDir != -1 && count == 0)
        {
            dir = NextDir;
            NextDir = -1;
        }

        float x = transform.position.x + dx[dir] * 0.05f;
        float y = transform.position.y + dy[dir] * 0.05f;

        if ((x < oldPosition.x - 19.5) || (x > oldPosition.x) || (y < oldPosition.y) || (y > oldPosition.y + 9.5))
        {
            transform.position = oldPosition;
            dir = 2;
            count = 0;
        }
        else
        {
            transform.Translate(new Vector3(dx[dir] * 0.05f, dy[dir] * 0.05f, 0));
            count++;
        }

    }
}