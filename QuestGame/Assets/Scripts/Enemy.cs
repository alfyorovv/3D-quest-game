using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp = 30;
    private Animator animator;
    private Collider enemyCollider;
    private Weapon weapon;

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
        weapon = GameObject.FindGameObjectWithTag("EquipedWeapon").GetComponent<Weapon>(); //Helps to know which weapon is picked
        hp -= weapon.GetDamage();
        animator.SetTrigger("getDamage");
    }

    public void Death()
    {
        animator.SetTrigger("dead");
        enemyCollider.enabled = false;
    }
}
