using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    private PlayerController playerController;
    private LevelEnder levelEnder;

    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        levelEnder = GameObject.FindGameObjectWithTag("LevelEnder").GetComponent<LevelEnder>();
    }

    void Update()
    {
        if(levelEnder.levelPassed){
            Debug.Log("Go somewhere in menu");
            playerController.SetPlayerState("Waiting");
        }
    }
}
