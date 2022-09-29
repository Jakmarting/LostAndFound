using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int dmg;
    public float knockback;
    public float speed;
    public float lifeTimer;
    public bool spins = false;

    private float spinSpeed = 20f;

    private Vector3 moveVector = new Vector3(1, 0, 0);
    private float angle;
    private Rigidbody2D rb;

    void Start()
    {
        Destroy(gameObject, lifeTimer);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += moveVector * Time.fixedDeltaTime * speed;
        rb.gravityScale = 0;
        if (spins)
        {
            transform.Rotate(0,0,spinSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Target"))
        {
            collision.gameObject.GetComponent<Target>().Damage(this);
        }

        if (collision.gameObject.tag.Equals("Ground"))
        {
            speed = 0;
            if (spins) spins = false;
        }
        else
        {
            Destroy(gameObject);
        }
        /*
        switch (collision.gameObject.tag)
        {
            case "Target":
                collision.gameObject.GetComponent<Target>().Damage(this);
                Destroy(gameObject);
                break;

            case "Ground":
                Destroy(gameObject);
                break;
        }
        */
    }

    public Vector3 GetMoveVector()
    {
        return moveVector;
    }
    public void SetMoveVector(Vector3 v)
    {
        moveVector = v;
    }
}
