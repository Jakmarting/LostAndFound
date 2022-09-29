using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{

    public float speed;

    void Move()
    {
        transform.position += -transform.up * Time.deltaTime * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) // Ground layer
        {
            transform.Rotate(0f,0f, Random.Range(160.0f, 200.0f));
            Move();
        }
    }

}
