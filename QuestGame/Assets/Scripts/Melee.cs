using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private float fightRadius = 1f;
    [SerializeField] private float attackCoolDown = 0.3f;

    private Animator animator;
    private Enemy enemy;
    private bool canAttack = true;

    public GameObject damageSphere;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemy = FindObjectOfType<Enemy>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && canAttack && gameObject.transform.childCount != 0) //Mouse clicked, attack cooldown finished and have any weapon equiped
        {
            animator.SetTrigger("attack");

            LayerMask enemiesLayerMask = LayerMask.GetMask("Enemies");
            Collider[] hitColliders = Physics.OverlapSphere(damageSphere.transform.position, fightRadius, enemiesLayerMask);

            foreach (var hitCollider in hitColliders)
            {
                enemy.GetDamage();
            }
            StartCoroutine(AttackDelay());
        }
    }

    private IEnumerator AttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCoolDown);
        canAttack = true;
    }
}
