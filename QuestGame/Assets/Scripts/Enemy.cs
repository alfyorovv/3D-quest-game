using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp = 3;
    private Animator animator;
    private Collider collider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }

    private void Update()
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
        collider.enabled = false;
    }
}
