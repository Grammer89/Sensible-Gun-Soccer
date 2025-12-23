using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBall : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 0.2f;
    // Start is called before the first frame update

    // Update is called once per frame
    public void Movement(Vector2 direction)
    {
        _rb.velocity = direction.normalized * _speed;
    }
}
