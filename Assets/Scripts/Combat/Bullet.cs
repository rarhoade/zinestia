using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }
}
