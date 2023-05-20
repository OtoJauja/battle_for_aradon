using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength;
    private float invincibleCounter;

    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }
    }

    public void DealDamage()
    {
        if (invincibleCounter <= 0)
        {
        currentHealth--;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            gameObject.SetActive(false);
        }else
        {
            invincibleCounter = invincibleLength;
        }

        UIController.instance.UpdateHealthDisplay();
        }
    }
}
