using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tapTapManager : MonoBehaviour {

    private RaycastHit2D hit;
    private GameObject[] TapTags;
    public GameObject Tap1, Tap2;
    private Touch touch;
    private int score1 = 0, score2 = 0, count=0;

    public Text Score1;
    public Text Score2;

    public Sprite laser1, laser2;

    void Start ()
    {
        Invoke("GenerateTap", 2f);
    }

    void GenerateTap()
    {
        count++;
        Instantiate(Tap2, new Vector2(Random.Range(0.5f, 5f), Random.Range(-3.5f, 3.5f)), Quaternion.identity);
        Instantiate(Tap1, new Vector2(Random.Range(-0.5f, -5f), Random.Range(-3.5f, 3.5f)), Quaternion.identity);

        if (count != 20)
            Invoke("GenerateTap", 0.2f);
    }

    void Update()
    {
        for (int i = 0; i < Input.touchCount && Input.touchCount>0 ; i++)
        {
            touch = Input.GetTouch(i);


            if (touch.phase.Equals(TouchPhase.Began))
            {

                Vector2 worldTouchPos = Camera.main.ScreenToWorldPoint(touch.position);
                hit = Physics2D.Raycast(worldTouchPos, Vector2.zero);

                if (hit.collider.gameObject.tag == "Tap")
                {
                    if (hit.collider.gameObject.transform.position.x < 0)
                    {
                        score1++;
                        Score1.text = score1.ToString();
                    }
                    else
                    {
                        score2++;
                        Score2.text = score2.ToString();
                    }

                    Destroy(hit.collider.gameObject);
                }

                if (Score2.text == "20" || Score1.text == "20")
                {
                    enabled = false;
                }
            }
        }

    }
}
