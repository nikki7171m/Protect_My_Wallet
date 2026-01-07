using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrendyChiMonster : Monster
{
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
