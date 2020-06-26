using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    

    [SerializeField] int damage = 10;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.tag == "Player"){
            GiveDamage(collidedObject.gameObject.GetComponent<MainPlayer>(), damage);
        }
    }

    void GiveDamage(MainPlayer player, int value){
        player.GetDamage(damage);

    }


}
