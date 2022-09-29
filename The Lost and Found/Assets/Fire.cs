using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] bool eternal;
    [SerializeField] float lifeTime;
    [SerializeField] int fireDamage;
    [SerializeField] float intensity;
    [SerializeField] float fireHurtRate;

    float hurtTimer;

    void Start()
    {
        if (!eternal)
        {
            Destroy(gameObject, lifeTime);
        }
        hurtTimer = Time.time;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (hurtTimer < Time.time)
        {
            switch (other.gameObject.tag)
            {
                case "Target":
                    other.gameObject.GetComponent<Target>().Damage(fireDamage, new Vector3(0, intensity, 0));
                    break;

                case "Player":
                    break;
            }
            hurtTimer = Time.time + fireHurtRate;
        }
    }

    public void FireSetup(float set_lifeTime, int set_fireDamage, float set_intensity,float set_fireHurtRate)
    {
        lifeTime = set_lifeTime;
        fireDamage = set_fireDamage;
        intensity = set_intensity;
        fireHurtRate = set_fireHurtRate;
    }

}
