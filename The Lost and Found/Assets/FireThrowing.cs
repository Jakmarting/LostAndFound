using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireThrowing : MonoBehaviour
{
    [SerializeField] GameObject firePrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate;
    [SerializeField] int fires;

    float fireTimer;

    void ThrowFire()
    {
        GameObject f = Instantiate(firePrefab, new Vector3(firePoint.position.x + Random.Range(-1f, 1f), firePoint.position.y, 0), Quaternion.identity);
        f.GetComponent<Fire>().FireSetup(3f,2,0.4f,0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > fireTimer)
        {
            for (int i = 0; i < fires; i++)
            {
                ThrowFire();
            }
            fireTimer = Time.time + fireRate;
        }
    }
}
