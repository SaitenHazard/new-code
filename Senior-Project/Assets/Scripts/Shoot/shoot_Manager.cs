﻿using UnityEngine;

public class shoot_Manager : MonoBehaviour {
    public GameObject bullet1, bullet2;
    public GameObject player1, player2;

    private Rigidbody2D rigidPlayer1, rigidPlayer2;
    private float bulletSpeed = 6f;

    void Start () {
        rigidPlayer1 = player1.GetComponent<Rigidbody2D>();
        rigidPlayer2 = player2.GetComponent<Rigidbody2D>();

        Invoke("Shoot", 0.75f);
    }

    void Shoot()
    {
        if (!isActiveAndEnabled)
        {
            return;
        }

        (Instantiate(bullet1, new Vector2(rigidPlayer1.transform.position.x + 1f, rigidPlayer1.transform.position.y), Quaternion.identity))
        .GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0f);

        (Instantiate(bullet2, new Vector2(rigidPlayer2.transform.position.x - 1f, rigidPlayer2.transform.position.y), Quaternion.identity))
            .GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * -1, 0f);

        Invoke("Shoot", 0.75f);
    }

    void Player1Move(Touch touch, Vector2 touchedPos)
    {
        if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        {
            if(touchedPos.x<0)
            {
                touchedPos.x = rigidPlayer1.transform.position.x;
                rigidPlayer1.transform.position = Vector2.Lerp(rigidPlayer1.transform.position, touchedPos, Time.deltaTime*2);
            }
        }
    }

    void Player2Move(Touch touch, Vector2 touchedPos)
    {
        if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        {
            if(touchedPos.x>0)
            {
                touchedPos.x = rigidPlayer2.transform.position.x;
                rigidPlayer2.transform.position = Vector2.Lerp(rigidPlayer2.transform.position, touchedPos, Time.deltaTime*2);
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

    void Update()
    {
        moveController();
    }
}
