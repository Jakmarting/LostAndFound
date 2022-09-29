using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health;
    public bool killable;
    public float knockbackModifier;

    private float hitTimer = 0f;
    private Color returnColor;
    private SpriteRenderer m_SpriteRenderer;
    private float r, g, b;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        returnColor = m_SpriteRenderer.color;
        r = returnColor.r;
        g = returnColor.g;
        b = returnColor.b;
    }

    public void Damage(int d, Vector3 knockbackVector)
    {
        health -= d;
        r = 1f;
        g = 1f;
        b = 1f;
        m_SpriteRenderer.color = new Color(r, g, b);
        hitTimer = 1f;
        transform.position += knockbackVector * knockbackModifier;
    }

    public void Damage(Projectile p)
    {
        health -= p.dmg;
        r = 1f;
        g = 1f;
        b = 1f;
        m_SpriteRenderer.color = new Color(r, g, b);
        hitTimer = 1f;
        transform.position += p.GetMoveVector() * knockbackModifier;
    }


    void Update()
    {
        r -= Time.deltaTime;
        g -= Time.deltaTime;
        b -= Time.deltaTime;

        if (r < returnColor.r) r = returnColor.r;
        if (g < returnColor.g) g = returnColor.g;
        if (b < returnColor.b) b = returnColor.b;

        m_SpriteRenderer.color = new Color(r, g, b);
        
        if (health <= 0 && killable)
        {
            Destroy(this.gameObject);
        }
    }
}
