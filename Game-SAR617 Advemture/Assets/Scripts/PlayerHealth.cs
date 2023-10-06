using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currHealth;

    public HealthBar healthBar;
    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(20);
        }

        if(other.gameObject.tag == "Coin")
        {
            AddToHealth(20);
        }
    }

    

    void TakeDamage(int damage)
    {
        currHealth -= damage;
        healthBar.SetHealth(currHealth);
    }

    void AddToHealth(int health)
    {
        currHealth += health;
        healthBar.SetHealth(currHealth);
    }
}
