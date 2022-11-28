using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    public float speed; //Speed at which the block moves
    public bool Up = false; //var used for movement
    public bool Down = false; //var used for movement
    public bool Right = false; //var used for movement
    public bool Left = false; //var used for movement
    private UIManager _uiManager; //used for the score system
    private bool canMove = true; //var used to disable multiple movement inputs at once.

    Color[] colors = new Color[4];

    void Start()
    {
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen

        speed = 15f;

        colors[0] = Color.red;
        colors[1] = Color.yellow;
        colors[2] = Color.blue;
        colors[3] = Color.green;

        GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)]; //Random colour at respawn

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    void Update()
    {
        if (Input.touchCount == 1 && canMove == true) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if (lp.x > fp.x)  //If the movement was to the Right)
                        {   //Right swipe                        
                            Right = !Right;
                            canMove = false;
                        }
                        else
                        {   //Left swipe
                            Left = !Left;
                            canMove = false;
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y && canMove == true)  //If the movement was up
                        {   //Up swipe
                            Up = !Up;
                            canMove = false;
                        }
                        else
                        {   //Down swipe
                            Down = !Down;
                            canMove = false;
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                }

                

            }
        }

        if (Right) {
            transform.Translate(Vector3.right * speed);
        }
        if (Left) { 
            transform.Translate(Vector3.left * speed);
        }
        if (Up) { 
            transform.Translate(Vector3.up * speed);
        }
        if (Down) { 
            transform.Translate(Vector3.down * speed);
        }

        //Respawn Mechanic and Scoring system

        if (transform.position.y >= 430f)
        {
            transform.position = new Vector3(-22, 195, -40);
            GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
            Up = false;
            canMove = true;
        }

        if (transform.position.y >= 420f && GetComponent<MeshRenderer>().material.color == Color.red && _uiManager._gameOver == false)
        {
            if (_uiManager != null)
            {
                _uiManager.UpdateScore();
            }
        }


        if (transform.position.y <= -50f)
        {
            transform.position = new Vector3(-22, 195, -40);
            GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
            Down = false;
            canMove = true;
        }

        if (transform.position.y <= -40f && GetComponent<MeshRenderer>().material.color == Color.green && _uiManager._gameOver == false)
        {
            if (_uiManager != null)
            {
                _uiManager.UpdateScore();
            }
        }


        if (transform.position.x >= 180f)
        {
            transform.position = new Vector3(-22, 195, -40);
            GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
            Right = false;
            canMove = true;
        }

        if (transform.position.x >= 170f && GetComponent<MeshRenderer>().material.color == Color.blue && _uiManager._gameOver == false)
        {
            if (_uiManager != null)
            {
                _uiManager.UpdateScore();
            }
        }


        if (transform.position.x <= -180f)
        {
            transform.position = new Vector3(-22, 195, -40);
            GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
            Left = false;
            canMove = true;
        }

        if (transform.position.x <= -170f && GetComponent<MeshRenderer>().material.color == Color.yellow && _uiManager._gameOver == false)
        {
            if (_uiManager != null)
            {
                _uiManager.UpdateScore();
            }
        }
    }

}
