using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalelyMonster : Monster
{
    [SerializeField] private Rigidbody2D prefabFire1;
    [SerializeField] private float maxDelay;
    private float delay = 0;
    [SerializeField] private float distance;

    [SerializeField] private Slider slider;
    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = maxDelay;
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

    protected override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < distance)
        {
            speed = 0;
            if (speed == 0 && delay > 0 && hp > 0)
            {
                slider.value += Time.deltaTime;
                delay -= Time.deltaTime;
            }
            else if (speed == 0 && delay <= 0)
            {
                FindObjectOfType<AudioManager>().Play("Fire");
                Rigidbody2D prefabFire1Instan;
                Rigidbody2D prefabFire2Instan;
                prefabFire1Instan = Instantiate(prefabFire1, transform.position, Quaternion.identity);
                prefabFire1Instan.AddForce(transform.up * -50);
                prefabFire2Instan = Instantiate(prefabFire1, transform.position, Quaternion.identity);
                prefabFire2Instan.AddForce(transform.up * 50);
                slider.value = 0;
                delay = maxDelay;
            }
        }
        else
            speed = baseSpeed + extraSpeed;
    }
}
