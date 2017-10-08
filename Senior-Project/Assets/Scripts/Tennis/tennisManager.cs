﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tennisManager : MonoBehaviour {
    public GameObject player1, player2, ball;
    private Rigidbody2D rigidPlayer1, rigidPlayer2,rb;

    private float ballInitalVelocity = 0.01f;

    void Start()
    {
        rigidPlayer1 = player1.GetComponent<Rigidbody2D>();
        rigidPlayer2 = player2.GetComponent<Rigidbody2D>();
        rb = ball.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(ballInitalVelocity, ballInitalVelocity));
        //Invoke("invoke", 1f);
    }

    void invoke()
    {
        Debug.Log(ballInitalVelocity);

        rb.AddForce(rb.velocity.normalized * ballInitalVelocity);

        ballInitalVelocity += 0.00001f;
        Invoke("invoke", 1f);
    }

    void Player1Move(Touch touch, Vector2 touchedPos)
    {
        if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        {
            if (touchedPos.x < 0)
            {
                touchedPos.x = rigidPlayer1.transform.position.x;
                rigidPlayer1.transform.position = Vector2.Lerp(rigidPlayer1.transform.position, touchedPos, Time.deltaTime);
            }
        }
    }

    void Player2Move(Touch touch, Vector2 touchedPos)
    {
        if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        {
            if (touchedPos.x > 0)
            {
                touchedPos.x = rigidPlayer2.transform.position.x;
                rigidPlayer2.transform.position = Vector2.Lerp(rigidPlayer2.transform.position, touchedPos, Time.deltaTime);
            }
        }
    }

    void moveController()
    {
        Touch touch1, touch2, touchTemp;
        Vector2 touchedPos1, touchedPos2, touchedPosTemp;

        if (Input.touchCount == 1)
        {
            touch1 = Input.GetTouch(0);
            touchedPos1 = Camera.main.ScreenToWorldPoint(new Vector2(touch1.position.x, touch1.position.y));

            if (touchedPos1.x < 0)
            {
                Player1Move(touch1, touchedPos1);
            }
            else
            {
                Player2Move(touch1, touchedPos1);
            }

        }

        if (Input.touchCount > 1)
        {
            touch1 = Input.GetTouch(0); touch2 = Input.GetTouch(1);
            touchedPos1 = Camera.main.ScreenToWorldPoint(new Vector2(touch1.position.x, touch1.position.y));
            touchedPos2 = Camera.main.ScreenToWorldPoint(new Vector2(touch2.position.x, touch2.position.y));

            if (!(touchedPos1.x < 0))
            {
                touchTemp = touch1;
                touch1 = touch2;
                touch2 = touchTemp;

                touchedPosTemp = touchedPos1;
                touchedPos1 = touchedPos2;
                touchedPos2 = touchedPosTemp;
            }

            Player1Move(touch1, touchedPos1);
            Player2Move(touch2, touchedPos2);
        }
    }

    void Update ()
    {
        moveController();
    }
}