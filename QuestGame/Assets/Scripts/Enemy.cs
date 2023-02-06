using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp = 3;
    private Animator animator;
    private Collider enemyCollider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider>();
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
        enemyCollider.enabled = false;
    }
}
