using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakeDamage : MonoBehaviour
{
    private PlayerControls controls;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar hb;
    private void Awake()
    {
        controls = new PlayerControls();
    }
    // Start is called before the first frame update
    void Start()
    {
        hb.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // Update is called once per frame
        if (controls.Player.Jump.triggered) {
            takeDamage(15);
            hb.setHealth(currentHealth);
        }
    }

    void takeDamage(int damage) {
        currentHealth -= damage;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
