using UnityEngine;

public class destroy_bulletBullet : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D collision)
    {
           Destroy(collision.gameObject);
    }
}
