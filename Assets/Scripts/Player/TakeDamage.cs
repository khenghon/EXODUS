using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class TakeDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar hb;
    public Image healthCanvas;
    public GameObject anim;

    private Image backgroundColorReference;
    private int regenerationCd = 2;
    private int regenerationRate = -20;
    private bool isRegenHealth = false;

    // Start is called before the first frame update
    void Start()
    {
        // get health as background color reference
        backgroundColorReference = healthCanvas.GetComponent<Image>();
        
        // set Max health for healthBar + Health Canvas
        hb.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
        setNewHealthCanvas(0);

        // set health pusalting to false
        anim.SetActive(false);
    }

    private void Update()
    {
        // Update is called once per frame
        if (Input.GetKeyDown(KeyCode.Space)) {
            takeDamage(15);
            hb.setHealth(currentHealth);
            setNewHealthCanvas(0.15f);

            // trigger health pulsating
            if (currentHealth < 50)
                anim.SetActive(true);
        }
        if (currentHealth >= 50) 
            anim.SetActive(false);
        if (currentHealth <= maxHealth && !isRegenHealth)
            StartCoroutine(RegainHealthOverTime());

    }

    private IEnumerator RegainHealthOverTime()
    {
        isRegenHealth = true;
        while (currentHealth < maxHealth)
        {
            takeDamage(regenerationRate);
            hb.setHealth(currentHealth);
            yield return new WaitForSeconds(regenerationCd);
        }
        isRegenHealth = false;
        
    }

    void takeDamage(int damage) {
        if (currentHealth - damage < 0)
            currentHealth = 0;
        currentHealth -= damage;
    }

    private void setNewHealthCanvas(float newObaqueValue)
    {
        var tempColor = backgroundColorReference.color;
        tempColor.a += newObaqueValue;
        backgroundColorReference.color = tempColor;
    }
}
