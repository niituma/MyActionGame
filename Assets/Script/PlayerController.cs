using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpPower = 5f;
    float h, v = 0;
    Vector3 _dir;
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        _dir = new Vector3(h, 0, v);
        Move();
        Jump();
    }

    void Move()
    {
        float speed = _dir == Vector3.zero ? 0 : _speed;

        //_animationspeed = Mathf.Lerp(_animationspeed, speed, Time.deltaTime * 5f);

        _rb.AddForce(_dir.normalized * speed, ForceMode.Force);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }
}
