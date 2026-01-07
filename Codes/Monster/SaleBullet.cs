using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleBullet : Monster
{
    void Start()
    {
        hp = baseHp + extraHp;
        speed = baseSpeed + extraSpeed;
        hitDamage = baseHitDamage + extraHitDamage;
        reduceMoney = baseReduceMoney + extraReduceMoney;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        box2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
    }

    protected void Update()
    {
        Move();
        Die();
        TurnDirection();
    }

    protected void OnMouseDown()
    {
        if (Time.timeScale == 1)
        {
            TakeDamage(hitDamage);
            FindObjectOfType<AudioManager>().Play("Clikck_Monster");
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            MoneyManager.moneyManager.ReduceMoney(reduceMoney);
            MoneyManager.moneyManager.LostMoney(reduceMoney);
        }
    }
    protected override void Die()
    {
        if (hp <= 0)
        {
            box2d.enabled = false;
            sp.color = new Color32(255, 255, 255, 150);
            speed = 0f;
            Destroy(gameObject, 1f);
        }
    }
}
