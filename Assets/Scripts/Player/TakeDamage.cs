using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar hb;
    public Image healthCanvas;

    private Image backgroundColorReference;

    // Start is called before the first frame update
    void Start()
    {
        // get health as background color reference
        backgroundColorReference = healthCanvas.GetComponent<Image>();
        
        // set Max health for healthBar + Health Canvas
        hb.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
        setNewHealthCanvas(0);
    }

    private void Update()
    {
        // Update is called once per frame
        if (Input.GetKeyDown(KeyCode.Space)) {
            takeDamage(15);
            hb.setHealth(currentHealth);
            setNewHealthCanvas(0.15f);
        }
    }

    void takeDamage(int damage) {
        currentHealth -= damage;
    }

    private void setNewHealthCanvas(float newObaqueValue)
    {
        var tempColor = backgroundColorReference.color;
        tempColor.a += newObaqueValue;
        backgroundColorReference.color = tempColor;
    }
}
