using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerController))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float horizontalForce = 200f;
    [SerializeField] float verticalForce = 250f;
    [SerializeField] float maximumSpeed = 350f;
    [SerializeField] float maxMagnitude = 5f;
    [SerializeField] float spacePower = 3f;
    [SerializeField] float dashPower = 2f;
    [SerializeField] float maxGrippingDistanceToWall = 10f;
    [SerializeField] float gripPower = 2f;

    private Rigidbody2D rb2D;
    private PlayerController playerController;

    private float spaceForce;
    private bool isLoadingForce = false;
    private RaycastHit2D wallRaycast;

    private void Awake() {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        playerController = gameObject.GetComponent<PlayerController>();
    }
    

    void Update()
    {

        if(!playerController.IsPlayerInMovingState()){
            return;
        }
        
        if(CanPlayerGripToWall() && Input.GetKey(KeyCode.Q)){
            Move("grip");
            return;
        }

        if (Input.GetKey(KeyCode.LeftControl)){
            if (Input.GetKeyUp(KeyCode.A)){
               Move("a_dash"); 
            }
            else if(Input.GetKeyUp(KeyCode.D)){
                Move("d_dash");
            }
        }
        else
        {
            if (Input.GetKeyDown("a")){
                Move("a");
            }
            else if (Input.GetKeyDown("d")){
                Move("d");
            }
            else if (Input.GetKeyDown("w")){
                Move("w");
            }

            if (Input.GetKeyDown("space")){
                spaceForce = 0f;
                isLoadingForce = true;
            }

            if (Input.GetKey("space") && isLoadingForce){
                spaceForce += spacePower;
            }

            if (Input.GetKeyUp("space")){
                isLoadingForce = false;

                if (spaceForce > maximumSpeed){
                    spaceForce = maximumSpeed;
                }

                JumpUp(spaceForce);
            }
        }

        
    }

    void Move(string inputKey){
        rb2D.velocity = new Vector2(0.0f, rb2D.velocity.y);

        switch (inputKey){
            case "a":
                Vector2 left_velocity = new Vector2(-horizontalForce, verticalForce);
                rb2D.AddForce(left_velocity);
                break;
            case "d":
                Vector2 right_velocity = new Vector2(horizontalForce, verticalForce);
                rb2D.AddForce(right_velocity);
                break;
            case "w":
                Vector2 up_velocity = new Vector2(0, verticalForce);
                rb2D.AddForce(up_velocity);
                break;
            case "a_dash":
                Vector2 left_dash_velocity = new Vector2(-horizontalForce * dashPower, 0);
                rb2D.AddForce(left_dash_velocity);
                break;
            case "d_dash":
                Vector2 right_dash_velocity = new Vector2(horizontalForce * dashPower, 0);
                rb2D.AddForce(right_dash_velocity);
                break;
            case "grip":
                int direction = 1;

                //Direction check
                if(wallRaycast.transform.position.x - transform.position.x < 0){
                    direction = -1;
                }

                Vector2 grip_velocity = new Vector2(direction * horizontalForce * gripPower, 0);
                rb2D.AddForce(grip_velocity);
                break;
        }

        if (rb2D.velocity.magnitude > maxMagnitude){

            rb2D.velocity = new Vector2(0.0f, 0.0f);

            Vector2 velocity = new Vector2(rb2D.velocity.x, verticalForce);
            rb2D.AddForce(velocity);
        }

    }

    void JumpUp(float force){

        rb2D.velocity = new Vector2(rb2D.velocity.x, 0.0f);

        Vector2 velocity = new Vector2(0.0f, force);
        rb2D.AddForce(velocity);

    }

    bool CanPlayerGripToWall(){
        Vector2 playerPosition = transform.position;
        wallRaycast = Physics2D.Raycast(playerPosition, Vector2.left, maxGrippingDistanceToWall, 1 << LayerMask.NameToLayer("Wall"));

        if(wallRaycast.collider != null){
            return true;
        }

        return false;
    }

}
