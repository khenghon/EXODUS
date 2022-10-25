using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaSWING : MonoBehaviour
{
    public GameObject Sword;
    public float AttackCD = 1.0f;
    public bool CanAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("v"))
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
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCD());
    }
    IEnumerator ResetAttackCD()
    {
        yield return new WaitForSeconds(AttackCD);
        CanAttack = true;
    }
}
