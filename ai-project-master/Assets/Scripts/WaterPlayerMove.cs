using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPlayerMove : MonoBehaviour {

    private int[] dx = { 1, 0, -1, 0 };
    private int[] dy = { 0, 1, 0, -1 };
    private int dir = 0;
    private int NextDir = -1;
    private int count = 0;
    private Vector3 oldPosition;
    public GameObject da;
    public Transform Container;
    int gamePoint = 0;
    public Text txtPoint;
    // Use this for initialization
    void Start () {
        oldPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        count = count % 20;
        //if (count == 0) Instantiate(da, new Vector2(transform.position.x, transform.position.y), Quaternion.identity, Container);
        if (Input.GetKeyDown(KeyCode.W) && dir != 3) NextDir = 1;
        if (Input.GetKeyDown(KeyCode.D) && dir != 2) NextDir = 0;
        if (Input.GetKeyDown(KeyCode.A) && dir != 0) NextDir = 2; 
        if (Input.GetKeyDown(KeyCode.S) && dir != 1) NextDir = 3;
        
        if (NextDir != -1 && count == 0)
        {
            dir = NextDir;
            NextDir = -1;
        }

        float x = transform.position.x + dx[dir] * 0.05f;
        float y = transform.position.y + dy[dir] * 0.05f;

        if ((x < oldPosition.x) || (x > oldPosition.x + 19.5) || (y < oldPosition.y - 9.5) || (y > oldPosition.y))
        {
            transform.position = oldPosition;
            dir = 0; count = 0;
        }
        else
        {
            transform.Translate(new Vector3(dx[dir] * 0.05f, dy[dir] * 0.05f, 0));
            count++;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //gameController.GetComponent<GameController>().Getpoint();
        if (other.gameObject.CompareTag("flap"))
        {
           if(dir == 0)
            {
                Instantiate(da, new Vector2(transform.position.x + 0.05f, transform.position.y), Quaternion.identity, Container);
            }
            if (dir == 1)
            {
                Instantiate(da, new Vector2(transform.position.x, transform.position.y + 0.05f), Quaternion.identity, Container);
            }
            if (dir == 2)
            {
                Instantiate(da, new Vector2(transform.position.x - 0.05f, transform.position.y), Quaternion.identity, Container);
            }
            if (dir == 3)
            {
                Instantiate(da, new Vector2(transform.position.x, transform.position.y - 0.05f), Quaternion.identity, Container);
            }
            gamePoint += 10;
            Destroy(other);
        }
        if (other.gameObject.CompareTag("trap"))
        {
            transform.position = oldPosition;
            dir = 0; count = 0;
            gamePoint = 0;
        }

        congDiem();
    }
    void congDiem()
    {
        gamePoint++;
        txtPoint.text = "Point Water: " + gamePoint.ToString();
    }
}