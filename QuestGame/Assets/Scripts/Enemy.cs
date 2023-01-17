using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp = 3;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (hp <= 0)
        {
            Death();
        }
    }

    public void GetDamage()
    {
        hp -= 1;
        animator.SetTrigger("getDamage");
    }

    public void Death()
    {
        animator.SetTrigger("dead");
    }
}
