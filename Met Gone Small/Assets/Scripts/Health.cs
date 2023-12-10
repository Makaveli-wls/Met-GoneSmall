using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    

    private void Start()
    {
        health = maxHealth;
        
    }

   
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; // reduce health view an amount
        

        if(health <=0)
        {
            Destroy(gameObject);
        }
    }
}
