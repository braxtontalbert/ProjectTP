using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Players speed
    float minSpeed;
    float maxSpeed;
    float currentSpeed = 10f;
    float xMove;
    float zMove;
    Rigidbody playerRigidbody;
    float mouseSpeed = 4f;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    void PlayerMove() {

        xMove = Input.GetAxisRaw("Horizontal");
        zMove = Input.GetAxisRaw("Vertical");
        playerRigidbody.velocity = new Vector3(xMove, playerRigidbody.velocity.y, zMove) * currentSpeed;
        //transform.forward = playerRigidbody.velocity;
        MouseCameraMove();
    }
    void MouseCameraMove()
    {
        float X = Input.GetAxis("Mouse X") * mouseSpeed;
        float Y = Input.GetAxis("Mouse Y") * mouseSpeed;

        this.transform.Rotate(0, X, 0);

    }

    private void Update()
    {
        PlayerMove();
    }
}
