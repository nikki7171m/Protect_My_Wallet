using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCha : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float maxDelay;
    private float delay = 0;

    private void Update()
    {
        if (delay > 0)
            delay -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (delay <= 0 && collision.tag == "Enemy")
        {
            animator.SetTrigger("hitMonster");
            delay = maxDelay;       
        }
        FindObjectOfType<AudioManager>().Play("Money");
    }
}
