using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vechicleMove : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _VoorwielRB;
    [SerializeField] private Rigidbody2D _AchterwielRB;
    [SerializeField] private float _speed = 150f;
    public float _moveInput;

    private void update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        _VoorwielRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _AchterwielRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
    }
}