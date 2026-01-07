using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarelessMonster : Monster
{
    [SerializeField] private GameObject prefabDie;
    [SerializeField] private float timeAttack;
    [SerializeField] private float distance;

    [SerializeField] private Slider slider;

    [SerializeField] private Animator animator;
    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = timeAttack;
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
            if (speed == 0 && timeAttack > 0 && hp > 0)
            {
                slider.value += Time.deltaTime;
                timeAttack -= Time.deltaTime;       
            }
            else if (speed == 0 && timeAttack <= 0)
            {
                Instantiate(prefabDie, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else
            speed = baseSpeed + extraSpeed;
    }
    protected override void Die()
    {
        if (hp <= 0)
        {
            cir2d.enabled = false;
            sp.color = new Color32(255, 255, 255, 150);
            animator.SetBool("die", true);
            Destroy(gameObject, 1);
        }
    }
}
