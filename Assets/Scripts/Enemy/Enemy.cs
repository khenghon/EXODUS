using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 50;
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
            hb.setHealth(currentHealth);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die() {

        if (transform.CompareTag("Respawn"))
            GameObject.Find("Melee Test Area").GetComponent<respawn>().spawnEnemy("Respawn", transform.position, transform.rotation);
        if (transform.CompareTag("RespawnFiring"))
            GameObject.Find("Melee Test Area").GetComponent<respawn>().spawnEnemy("RespawnFiring", transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
