﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    private Vector3 _moveVector;
    private float _fallVelocity;
    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }

    void Update()
    {
        _moveVector = Vector3.zero;

        //Forward
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        //Backwards
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce; 
        }
        
    }
}
