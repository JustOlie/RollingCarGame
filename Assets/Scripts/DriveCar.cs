using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vechicleMove : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _VoorwielRB;
    [SerializeField] private Rigidbody2D _AchterwielRB;
    [SerializeField] private Rigidbody2D _VoertuigRB;
    [SerializeField] private float _speed = 150f;
    [SerializeField] private float _rotationSpeed = 300f;
    public float _moveInput;

    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        _VoorwielRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _AchterwielRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _VoertuigRB.AddTorque(_moveInput * _rotationSpeed * Time.fixedDeltaTime);
    }
}