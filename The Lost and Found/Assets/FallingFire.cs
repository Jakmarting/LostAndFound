using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFire : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        //if (other.gameObject.tag != "Ground") Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
