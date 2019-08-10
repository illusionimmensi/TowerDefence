using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    public float health;
    [HideInInspector]
    public float speed = 10f;

    public float startHealth = 100;

    public int worth = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthbar;

    private bool isDead = false;

    void start ()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        healthbar.fillAmount = health / startHealth; 

        if (health <= 0 && !isDead)
        {
            Die();
        }

    }
    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

   
}
