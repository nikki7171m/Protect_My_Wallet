using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GambleMonster : Monster
{
    [SerializeField] private int getMoney;
    private int random;

    [SerializeField] private float startWaitTime = 3;
    private float waitTime;

    [SerializeField] private Transform moveSpot;
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private Animator animator;

    [SerializeField] private float maxDelay;
    private float delay;

    private void Start()
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

        waitTime = startWaitTime;

        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        delay = maxDelay;
    }

    private void Update()
    {
        speed = baseSpeed + extraSpeed;
        Move();
        Die();
        TurnDirection();

        if (delay > 0)
            delay -= Time.deltaTime;
    }

    protected void OnMouseDown()
    {
        if (hp == baseHp)
        {  
            if (delay <= 0 && Time.timeScale == 1)
            {
                animator.SetTrigger("hit_Monster");
                FindObjectOfType<AudioManager>().Play("Clikck_Monster");
                delay = maxDelay;

                TakeDamage(hitDamage);
                MoneyManager.moneyManager.GetMoney(getMoney);
                //Debug.Log($"You Get Money = {getMoney}");
            }
        }
        else
        {
            if (delay <= 0 && Time.timeScale == 1)
            {
                animator.SetTrigger("hit_Monster");
                FindObjectOfType<AudioManager>().Play("Clikck_Monster");
                delay = maxDelay;

                TakeDamage(hitDamage);
                random = Random.Range(0, 100);
                //Debug.Log($"Random is {random}");

                if (random == 0)
                {
                    MoneyManager.moneyManager.GetMoney(getMoney / 2);
                    //Debug.Log($"You Get Money = {getMoney / 2}");
                }
                else
                {
                    MoneyManager.moneyManager.ReduceMoney(reduceMoney);
                    MoneyManager.moneyManager.LostMoney(reduceMoney);
                    //Debug.Log($"You Reduce Money = {reduceMoney}");
                }
            }
        }
    }

    protected override void TurnDirection()
    {
        if (transform.position.x > moveSpot.position.x)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }
    }

    protected override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
                waitTime -= Time.deltaTime;
        }
    }

    protected override void Die()
    {
        Destroy(gameObject, 20f);
    }
}
