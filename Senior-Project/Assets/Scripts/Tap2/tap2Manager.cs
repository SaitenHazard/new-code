using UnityEngine.UI;
using UnityEngine;

public class tap2Manager : MonoBehaviour {

    public GameObject Tap, Bullet;
    public int score1 = 0, score2 = 0;
    public Text text1, text2;

    private int count = 0;
    private float bulletSpeed = 6f;
    

    void Start()
    {
        Invoke("GenerateTap", 2f);
    }

    void GenerateTap()
    {
        count++;
        Instantiate(Tap, new Vector2(Random.Range(0f, 0f), Random.Range(-4.5f, 4.5f)), Quaternion.identity);

        if (count != 30)
            Invoke("GenerateTap", 0.2f);
    }

    void Update ()
    {
        ShootController();
        text1.text = score1.ToString();
        text2.text = score2.ToString();
    }

    void ShootController()
    {
        Touch touch1, touch2;
        Vector2 touchedPos1, touchedPos2;

        if (Input.touchCount == 1)
        {
            touch1 = Input.GetTouch(0);
            touchedPos1 = Camera.main.ScreenToWorldPoint(new Vector2(touch1.position.x, touch1.position.y));

            if(touch1.phase == TouchPhase.Began)
            {
                if (touchedPos1.x < 0)
                {
                    Instantiate(Bullet, new Vector2(Random.Range(-6f, -6f), Random.Range(touchedPos1.y, touchedPos1.y)), Quaternion.identity)
                        .GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0f);
                }
                else
                {
                    Instantiate(Bullet, new Vector2(Random.Range(6f, 6f), Random.Range(touchedPos1.y, touchedPos1.y)), Quaternion.identity)
                        .GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * -1, 0f);
                }
            }
        }

        if (Input.touchCount > 1)
        {
            touch1 = Input.GetTouch(0); touch2 = Input.GetTouch(1);
            touchedPos1 = Camera.main.ScreenToWorldPoint(new Vector2(touch1.position.x, touch1.position.y));
            touchedPos2 = Camera.main.ScreenToWorldPoint(new Vector2(touch2.position.x, touch2.position.y));

            if (touch1.phase == TouchPhase.Began)
            {
                if (touchedPos1.x < 0)
                {
                    Instantiate(Bullet, new Vector2(Random.Range(-6f, -6f), Random.Range(touchedPos1.y, touchedPos1.y)), Quaternion.identity)
                        .GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0f);
                }
                else
                {
                    Instantiate(Bullet, new Vector2(Random.Range(6f, 6f), Random.Range(touchedPos1.y, touchedPos1.y)), Quaternion.identity)
                        .GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * -1, 0f);
                }
            }

            if (touch2.phase == TouchPhase.Began)
            {
                if (touchedPos2.x < 0)
                {
                    Instantiate(Bullet, new Vector2(Random.Range(-6f, -6f), Random.Range(touchedPos2.y, touchedPos2.y)), Quaternion.identity)
                        .GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0f);
                }
                else
                {
                    Instantiate(Bullet, new Vector2(Random.Range(6f, 6f), Random.Range(touchedPos2.y, touchedPos2.y)), Quaternion.identity)
                        .GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * -1, 0f);
                }
            }
        }
    }
}
