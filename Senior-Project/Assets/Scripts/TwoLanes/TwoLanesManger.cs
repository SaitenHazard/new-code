using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoLanesManager : MonoBehaviour {

    GameObject Player1, Player2;
    Transform transform1, transform2;

    void Awake()
    {
        transform1 = Player1.GetComponent<Transform>();
        transform2 = Player2.GetComponent<Transform>();
    }

	// Use this for initialization
	void Start ()
    {
        Invoke("Generator", 3f);
    }

    void Generator()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        touch();
	}

    void touch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchedPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));

            if(touchedPos.y>0)
            {
                if(transform2.position.y==1.25f)
                {
                    transform2.position = new Vector2(transform2.position.x,3.75f);
                }
                else
                {
                    transform2.position = new Vector2(transform2.position.x, 1.75f);
                }
            }
            else
            {
                if (transform1.position.y == -1.25f)
                {
                    transform1.position = new Vector2(transform1.position.x, -3.75f);
                }
                else
                {
                    transform1.position = new Vector2(transform1.position.x, -1.75f);
                }
            }
        }
    }
}
