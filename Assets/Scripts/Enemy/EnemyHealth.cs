using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.value = calculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = calculateHealth();
        // Set health bar visible as long as it alives
        if (currentHealth < maxHealth) healthBarUI.SetActive(true);
        // out of HP, destroy all its object
        if (currentHealth <= 0) Destroy(gameObject);
    }

    // calculate health into range [0,1]
    float calculateHealth() {
        return currentHealth / maxHealth;
    }
}
