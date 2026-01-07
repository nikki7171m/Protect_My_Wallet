using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Monster : MonoBehaviour
{
    [SerializeField] protected int baseHp = 1;
    protected int hp;
    protected int extraHp = 0;
    [SerializeField] protected float baseSpeed = 5;
    protected float speed;
    protected float extraSpeed;
    [SerializeField] protected int baseHitDamage = 1;
    protected int hitDamage;
    protected int extraHitDamage = 0;
    [SerializeField] protected int baseReduceMoney = 10;
    protected int reduceMoney;
    protected int extraReduceMoney;

    protected Transform target;

    protected SpriteRenderer sp;
    protected CircleCollider2D cir2d;
    protected BoxCollider2D box2d;
    protected Rigidbody2D rb2d;

    void Start()
    {
        hp = baseHp + extraHp;
        speed = baseSpeed + extraSpeed;
        hitDamage = baseHitDamage + extraHitDamage;
        reduceMoney = baseReduceMoney + extraReduceMoney;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        cir2d = GetComponent<CircleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
    }

    protected virtual void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    protected virtual void TurnDirection()
    {
        if (transform.position.x > target.position.x)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }
    }

    protected virtual void Die()
    {
        if (hp <= 0)
        {
            cir2d.enabled = false;
            sp.color = new Color32(255, 255, 255, 150);
            speed = 0f;
            Destroy(gameObject, 1);
        }
    }

    protected virtual void TakeDamage(int hitDamage)
    {
        hp -= hitDamage;
    }
}
