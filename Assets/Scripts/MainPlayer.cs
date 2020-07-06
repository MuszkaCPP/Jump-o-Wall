using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : PlayerController
{
    
    private bool isDead = false;
    private int currentHealth = 100;

    public void GetDamage(int value){
        currentHealth -= value;

        if (currentHealth <= 0){
            isDead = true;
            currentHealth = 0;
            SetPlayerState("Dead");
        }

        Debug.Log("Current Health :" + currentHealth);

    }

}


