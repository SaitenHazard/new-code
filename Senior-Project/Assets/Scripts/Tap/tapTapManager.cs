using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tapTapManager : MonoBehaviour {

    private RaycastHit2D hit;
    private GameObject[] TapTags;
    public GameObject Tap;
    private Touch touch;
    public Text Score1;
    public Text Score2;

    void Start ()
    {
        Invoke("GenerateTap", 1f);
    }

    void GenerateTap()
    {

    }

    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            touch = Input.GetTouch(i);
            if (touch.phase.Equals(TouchPhase.Began))
            {

                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

                if (hit.collider.gameObject.tag == "Tap")
                {
                    if (hit.collider.gameObject.transform.position.x < 0)
                        Score1.text = Score1.text + 1;
                    else
                        Score2.text = Score2.text + 1;

                    Destroy(hit.collider.gameObject);
                }

                if(Score2.text == "20" || Score1.text == "20")
                {
                    enabled = false;
                }
            }
        }

    }
}
