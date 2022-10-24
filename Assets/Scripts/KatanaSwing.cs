using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaSwing : MonoBehaviour
{
    public GameObject Model_Sword_Cyber_Ninja;
    public bool canAttack = true;
    public float AttackCD = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {
                SwordAttack();

            }
        }
    }
    public void SwordAttack()
    {
        canAttack = false;
        Animator anim = Model_Sword_Cyber_Ninja.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCD());

    }
    IEnumerator ResetAttackCD()
    {
        yield return new WaitForSeconds(AttackCD);
        canAttack = true;
}
} 
