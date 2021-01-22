using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    private bool alive;

    private void Awake()
    {
        currentHealth = maxHealth;
        alive = true;
    }

    public void Damage(int amount)
    {
        if (!alive) return;
        currentHealth -= amount;
        if (currentHealth <= 0)
            Kill();
    }

    public void Heal(int amount)
    {
        if (currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
    }

    public bool IsAlive()
    {
        return alive;
    }

    public void Kill()
    {
        alive = false;
    }
}