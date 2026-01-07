using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarelessAttackMonster : Monster
{
    protected void Start()
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
        FindObjectOfType<AudioManager>().Play("Careless_attack");
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
}
