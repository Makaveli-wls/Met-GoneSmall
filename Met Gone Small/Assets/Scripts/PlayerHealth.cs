using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float maxHealth = 100.0f;
    public GameObject deathUI;
    public GameObject mainUI;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

    public void UpdateHealth(float mod) {
        playerHealth =+ mod;

    }


    // Update is called once per frame
    void Update()
    {
        if (playerHealth == 0)
        {
            PlayerDies();
        }

        if(Input.GetButton("Fire2") == true)
        {
            playerHealth = 0;
        }
    }

    public void PlayerDies()
    {
        Time.timeScale = 0;
        deathUI.SetActive(true);
        mainUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
