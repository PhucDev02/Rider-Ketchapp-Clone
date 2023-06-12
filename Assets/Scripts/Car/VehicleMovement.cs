using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = 20f;
    public float rotationSpeed = 2f;

    bool isTouching = false;
    public bool isOnGround = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !MouseInput.IsMouseOverUI() && GameController.Instance.gameOver == false)
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
        if (isTouching == true && InputManager.canTouch)
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
    private void OnCollisionExit2D()
    {
        isOnGround = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Booster"))
        {
            AudioManager.Instance.Play("Booster");
            body.AddForce(collision.gameObject.transform.right * speed 
                * Time.fixedDeltaTime * 500f, ForceMode2D.Force);
        }
    }

}
