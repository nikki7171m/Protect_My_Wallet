using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDie : MonoBehaviour
{
    private SpriteRenderer sp;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        sp.color = new Color32(255, 255, 255, 150);
    }

    void Update()
    {        
        Destroy(gameObject, 1);
        TurnDirection();
    }

    void TurnDirection()
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
}
