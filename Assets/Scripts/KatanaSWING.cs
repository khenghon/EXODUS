using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaSWING : MonoBehaviour
{
    public GameObject Sword;
    public float AttackCD = 0.5f;
    public bool CanAttack = true;

    public bool Attacking = false;
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                SwordAttack();
            }
        }
    }
    public void SwordAttack()
    {
        CanAttack = false;
        Attacking = true;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCD());
    }
    IEnumerator ResetAttackCD()
    {
        StartCoroutine(ResetAttackingCD());
        yield return new WaitForSeconds(AttackCD);
        CanAttack = true;
    }
    IEnumerator ResetAttackingCD()
    {
        yield return new WaitForSeconds(1.0f);
        Attacking = false;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if(Attacking == true && collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("RespawnFiring") || collision.gameObject.CompareTag("Respawn"))
        {
            Debug.Log(collision.gameObject.name);
            Enemy target = collision.gameObject.GetComponent<Enemy>();

            if (target != null){
                target.TakeDamage(damage);
                }

    }
    }
}
