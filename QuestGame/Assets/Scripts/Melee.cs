using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private float fightRadius = 1f;
    private Animator animator;
    private Enemy enemy;

    public GameObject damageSphere;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        enemy = FindObjectOfType<Enemy>();
    }

    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.transform.childCount != 0) //Mouse clicked and have any weapon equiped
        {
            animator.SetTrigger("attack");

            LayerMask enemiesLayerMask = LayerMask.GetMask("Enemies");
            Collider[] hitColliders = Physics.OverlapSphere(damageSphere.transform.position, fightRadius, enemiesLayerMask);

            foreach (var hitCollider in hitColliders)
            {
                enemy.GetDamage();
            }
        }
    }
}
