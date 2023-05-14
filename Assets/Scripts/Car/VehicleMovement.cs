using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    bool isTouching = false;
   public bool isOnGround = false;

    public Rigidbody2D body;

    public float speed = 20f;
    public float rotationSpeed = 2f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) &&!MouseInput.IsMouseOverUI() && GameController.Instance.gameOver == false)
        {
            isTouching = true;
            AudioManager.Instance.Play("Accelerate");
        }
        if (Input.GetMouseButtonUp(0))
        {
            isTouching = false;
            AudioManager.Instance.Stop("Accelerate");
        }
    }

    private void FixedUpdate()
    {
        if (isTouching == true&&InputManager.canTouch)
        {
            if (isOnGround)
            {
                body.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            else
            {
                if (body.angularVelocity <= 500)
                    body.AddTorque(rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
        }
        else
        {
            body.angularVelocity *= 0.97f;
        }
    }


    private void OnCollisionEnter2D()
    {
        isOnGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Booster"))
        {
            body.AddForce(collision.gameObject.transform.right * speed * Time.fixedDeltaTime * 1000f, ForceMode2D.Force);
        }
    }
    public float perfectFlipRotationThreshold = 180;

    private float totalRotaion;
    private Quaternion currentRotation;

}
