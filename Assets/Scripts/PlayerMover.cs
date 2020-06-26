using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float horizontalForce = 200f;
    [SerializeField] float verticalForce = 250f;
    [SerializeField] float MaximumSpeed = 350f;
    [SerializeField] float maxMagnitude = 5f;
    [SerializeField] float spacePower = 3f;
    [SerializeField] float dashPower = 2f;

    private float spaceForce;
    private bool isLoadingForce = false;
    private bool canMove = true;

    private Rigidbody2D rb2D;

    private void Awake() {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {

        if(!canMove){
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

            if (Input.GetKeyDown("space")){
                spaceForce = 0f;
                isLoadingForce = true;
            }

            if (Input.GetKey("space") && isLoadingForce){
                spaceForce += spacePower;
            }

            if (Input.GetKeyUp("space")){
                isLoadingForce = false;

                if (spaceForce > MaximumSpeed)
                {
                    spaceForce = MaximumSpeed;
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
            case "a_dash":

                Vector2 left_dash_velocity = new Vector2(-horizontalForce * dashPower, 0);
                rb2D.AddForce(left_dash_velocity);
                break;
            case "d_dash":

                Vector2 right_dash_velocity = new Vector2(horizontalForce * dashPower, 0);
                rb2D.AddForce(right_dash_velocity);
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

    public void setMoveState(bool state){
        canMove = state;
    }
}
