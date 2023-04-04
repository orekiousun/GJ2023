using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.name);
      Slime enemy =   collision.GetComponent<Slime>();
        if (enemy != null)
        {
            enemy.Death();
        }


        Destroy(gameObject);
    }


}