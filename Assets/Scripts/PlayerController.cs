using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private MainPlayer player;
    private PlayerMover playerMover;
    private PlayerStateEnum playerState;

    public enum PlayerStateEnum{
        Moving,
        Dead,
        Waiting
    }

    void Awake() {
        player = gameObject.GetComponent<MainPlayer>();
        playerMover = gameObject.GetComponent<PlayerMover>();
    }
    void Update()
    {
        
    }

    public void SetPlayerState(string playerState){
        switch(playerState){
            case "Moving":
                this.playerState = PlayerStateEnum.Moving;
                break;
            case "Dead":
                this.playerState = PlayerStateEnum.Dead;
                break;
            case "Waiting":
                this.playerState = PlayerStateEnum.Waiting;
                break;
        }
    }

    public PlayerStateEnum GetPlayerState(){
        return playerState;
    }
}
