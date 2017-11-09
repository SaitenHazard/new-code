using UnityEngine;
using UnityEngine.UI;

public class destroy : MonoBehaviour
{
    private GameObject Camera;

    private bool b = false;

    private tap2Manager tap2Manager;

    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        tap2Manager = Camera.GetComponent<tap2Manager>();

        if (this.gameObject.transform.position.x > 0)
        {
            b = true;
        }
    }

    void Update()
    {
        if (b == true)
        {
            if (this.gameObject.transform.position.x < 0)
                Destroy(this.gameObject);
        }
        else
        {
            if (this.gameObject.transform.position.x > 0)
                Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Tap")
        {
            if(b)
            {
                tap2Manager.score2++;
            }
            else
            {
                tap2Manager.score1++;
            }

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
