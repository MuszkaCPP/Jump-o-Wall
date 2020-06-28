using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnder : MonoBehaviour
{
    public bool levelPassed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.tag == "Player")
        {
            Debug.Log("Level Ended!");
            levelPassed = true;
        }
    }
}
