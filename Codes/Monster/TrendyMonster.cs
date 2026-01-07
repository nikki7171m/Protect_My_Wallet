using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrendyMonster : Monster
{
    [SerializeField] private Rigidbody2D prefabChi1, prefabChi2;
    [SerializeField] private Transform positionChi1, positionChi2;
    protected void Update()
    {
        Move();
        Die();
        TurnDirection();
    }

    protected void OnMouseDown()
    {
        if(Time.timeScale == 1)
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
            Rigidbody2D prefabChi2Instan;
            Instantiate(prefabChi1, positionChi1.transform.position, Quaternion.identity);
            prefabChi2Instan = Instantiate(prefabChi2, positionChi2.transform.position, Quaternion.identity);
            prefabChi2Instan.AddForce(transform.right * 10);
            FindObjectOfType<AudioManager>().Play("Trendy_Chi");
            Destroy(gameObject);
        }
    }
}
