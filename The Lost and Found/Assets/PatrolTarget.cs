using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolTarget : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    public float walkSpeed;
    public Collider2D bodyCollider;
    public Transform groundCheckPos;
    public LayerMask groundLayer;

    private bool mustTurn;

    void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        transform.position += new Vector3(walkSpeed * Time.fixedDeltaTime, 0f, 0f);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }
}
