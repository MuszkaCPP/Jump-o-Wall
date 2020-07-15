using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerController))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float horizontalForce = 200f;
    [SerializeField] float verticalForce = 250f;
    [SerializeField] float maxMagnitude = 7f;
    [SerializeField] float dashPower = 2f;
    [SerializeField] float maxGrippingDistanceToWall = 2f;
    [SerializeField] float gripPower = 2.5f;
    [SerializeField] float bouncePower = 40f;

    private Rigidbody2D rb2D;
    private PlayerController playerController;
    private RaycastHit2D leftWallRaycast;
    private Vector3 lastFrameVelocity;
    private void Awake() {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        playerController = gameObject.GetComponent<PlayerController>();
    }
    

    void Update()
    {
        lastFrameVelocity = rb2D.velocity;

        if(!playerController.IsPlayerInMovingState()){
            return;
        }
        
        if(CanPlayerGripToWall() && Input.GetKey(KeyCode.Space)){
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
        }

    }

    void Move(string inputKey){
        rb2D.velocity = new Vector2(0.0f,0.0f);
        Vector2 moveVelocity = new Vector2(horizontalForce, verticalForce);
        
        switch (inputKey){
            case "a":
                moveVelocity *= new Vector2(-1, 1);
                break;
            case "d":
                break;
            case "w":
                moveVelocity *= new Vector2(0, 1);
                break;
            case "a_dash":
                moveVelocity *= new Vector2(-1 * dashPower, 0);
                break;
            case "d_dash":
                moveVelocity *= new Vector2(dashPower, 0);
                break;
            case "grip":
                int direction = 1;

                if(leftWallRaycast.collider != null){
                    //Direction check
                    if(leftWallRaycast.transform.position.x - transform.position.x < 0){
                        direction = -1;
                    }
                }

                moveVelocity *= new Vector2(direction * gripPower, 0);
                break;
        }

        rb2D.AddForce(moveVelocity);

        if (rb2D.velocity.magnitude > maxMagnitude && -rb2D.velocity.magnitude > maxMagnitude){

            rb2D.velocity = Vector2.zero;

            Vector2 velocity = new Vector2(rb2D.velocity.x, verticalForce);
            rb2D.AddForce(velocity);
        }

    }

    bool CanPlayerGripToWall(){
        Vector2 playerPosition = transform.position;
        RaycastHit2D rightWallRaycast = Physics2D.Raycast(playerPosition, Vector2.right, maxGrippingDistanceToWall, 1 << LayerMask.NameToLayer("Wall"));

        leftWallRaycast = Physics2D.Raycast(playerPosition, Vector2.left, maxGrippingDistanceToWall, 1 << LayerMask.NameToLayer("Wall"));
        
        if(leftWallRaycast.collider != null || rightWallRaycast.collider != null){
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //Bouncing mechanism
        if (collision.collider.transform.tag == "Wall"){
            transform.Rotate(0,0,90);
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(lastFrameVelocity * new Vector2(-1 * bouncePower, 1.5f * bouncePower));
            transform.Rotate(0,0,-90);
        }
    }

}
