using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantterMoster : Monster
{
    [SerializeField] private GameObject prefabDie;
    [SerializeField] private Transform position;
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
            Instantiate(prefabDie, position.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
