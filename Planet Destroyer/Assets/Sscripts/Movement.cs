using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float accelerationMoveSpeed;
    public float rotationSpeed;
    public float accelerationRotationSpeed;

    private float currentSpeed;
    private float currentRotationSpeed;

    private void Update()
    {
        GetInputs();
        GetAccelerationButton();
        MoveForward();
        QuitGameButton();
    }

    private void QuitGameButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void MoveForward()
    {
        gameObject.transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    private void GetAccelerationButton()
    {
        if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.R))
        {
            currentSpeed = accelerationMoveSpeed;
            currentRotationSpeed = accelerationRotationSpeed;
        }
        else
        {
            currentSpeed = 0;
            currentRotationSpeed = rotationSpeed;
        }
    }

    private void GetInputs()
    {
        float XRot = Input.GetAxis("Vertical");
        float ZRot = Input.GetAxis("Horizontal");

        gameObject.transform.Rotate(new Vector3(XRot, 0, -ZRot) * currentRotationSpeed * Time.deltaTime);
    }
}
