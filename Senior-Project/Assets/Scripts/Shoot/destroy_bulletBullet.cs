using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_bulletBullet : MonoBehaviour {
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
    
}
