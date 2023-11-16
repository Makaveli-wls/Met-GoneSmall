using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayHealth : MonoBehaviour
{

    public TMP_Text health;
    PlayerHealth currentHealth;
   
    void Start()
    {
        currentHealth = GetComponent<PlayerHealth>();
       
        Display();
       
    }

    void Update()
    {
        Display();
    }

    void Display()
    {
        health.text = currentHealth.playerHealth.ToString(); 
    }
}
