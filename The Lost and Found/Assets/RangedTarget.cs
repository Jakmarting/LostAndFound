using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedTarget : MonoBehaviour
{
    // Currently these need to turn to face the player when the fire point isn't on the side of the target facing the player

    // Logic for a target that fires projectiles at the player

    [SerializeField] private Transform player;
    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float fireRate;
    [SerializeField] private float range;

    float nextFire;
    Vector2 projVector;
    float angle;

    bool isFacingLeft = true;

    void FireProjectiles()
    {
        GameObject p = Instantiate(ProjectilePrefab, FirePoint.position, Quaternion.Euler(Vector3.forward * angle));
        p.GetComponent<Projectile>().SetMoveVector(projVector);
    }

    float GetDistanceToPlayer()
    {
        return Vector2.Distance(this.gameObject.transform.position, player.position);
    }

    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Update()
    {
        projVector = (player.position - this.transform.position).normalized;
        angle = Mathf.Atan2(projVector.y, projVector.x) * Mathf.Rad2Deg;

        if ((player.position.x > this.transform.position.x && isFacingLeft) ||
            player.position.x < this.transform.position.x && !isFacingLeft)
        {
            Flip();

        }

        if (GetDistanceToPlayer() < range)
        {
            // Open fire on the player
            if (nextFire < Time.time)
            {
                // Fire a projectile at the firerate specified
                FireProjectiles();
                nextFire = Time.time + fireRate;
            }
        }
    }

}
