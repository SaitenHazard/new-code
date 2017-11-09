using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timingManager : MonoBehaviour {
    public GameObject[] pops;
    public GameObject p1, p2;

    private int pick;
    private float time;
    private bool b = false;

    void Start () {
        pick = Random.Range(0, 24);
        time = Random.Range(6f, 30f);
        Invoke("Poperator", time);
    }

    void Poperator()
    {
        b = true;
        Destroy(pops[pick]);
    }
	
	void Update ()
    {
        Touch touch;
        Vector2 touchedPos;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchedPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));

            if(b)
            {
                if(touchedPos.x < 0)
                {
                    Destroy(p2);
                }
                else
                {
                    Destroy(p1);
                }
            }
            else
            {
                if (touchedPos.x < 0)
                {
                    Destroy(p1);
                }
                else
                {
                    Destroy(p2);
                }
            }
        }
	}
}
