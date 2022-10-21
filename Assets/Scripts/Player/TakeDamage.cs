using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar hb;

    // Start is called before the first frame update
    void Start()
    {
        hb.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // Update is called once per frame
        if (Input.GetKeyDown(KeyCode.Space)) {
            takeDamage(15);
            hb.setHealth(currentHealth);
        }
    }

    void takeDamage(int damage) {
        currentHealth -= damage;
    }
}
