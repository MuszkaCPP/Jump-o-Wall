using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MainPlayer))]

public class PlayerController : MonoBehaviour
{   
    private MainPlayer player;
    private PlayerStateEnum playerState;

    public enum PlayerStateEnum{
        Moving,
        Dead,
        Waiting
    }

    void Awake() {
        player = gameObject.GetComponent<MainPlayer>();
    }

    //TODO: BETTER SETTER CONNECTED WITH SECURITY
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

    //change name of func
    public bool IsPlayerInMovingState(){
        if(playerState == PlayerStateEnum.Moving){
            return true;
        }

        return false;
    }
}
