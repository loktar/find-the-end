using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10;
    public float rotationSpeed = 150;
    public float jumpStrength = 10;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovePlayer();
        RotatePlayer();
        MaybeJump();
    }

    private void MovePlayer()
    {
        float moveForward = Input.GetAxis("Vertical");
        float moveSideways = Input.GetAxis("Horizontal");

        this.transform.position += this.transform.forward * moveForward * movementSpeed * Time.deltaTime;
        this.transform.position += this.transform.right * moveSideways * movementSpeed * Time.deltaTime;
    }

    private void RotatePlayer()
    {
        float rotateHorizontal = Input.GetAxis("Rotate Player");

        this.transform.eulerAngles += new Vector3(0, rotateHorizontal, 0) * rotationSpeed * Time.deltaTime;
    }

    private void MaybeJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, jumpStrength, 0));
        }
    }
}
