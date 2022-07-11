using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _walkSpeed = 5f;
    [SerializeField] float _runSpeed = 10f;
    float _animSpeed = 0f;
    [SerializeField] float _jumpPower = 5f;
    [SerializeField] float _isGroundedLength = 1.1f;
    [SerializeField] float _gravityPower = 0.93f;
    [SerializeField] float _turnSpeed = 2f;
    [SerializeField] int _jumpMaxCount = 2;
    public bool IsJump { get; set; } = false;
    int _jumpCount = 0;
    float h, v = 0;
    Vector3 _dir;
    Rigidbody _rb;

    public float AnimSpeed { get => _animSpeed; }

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

        _dir = Camera.main.transform.TransformDirection(_dir);
        // �J�����͎΂߉��Ɍ����Ă���̂ŁAY ���̒l�� 0 �ɂ��āuXZ ���ʏ�̃x�N�g���v�ɂ���
        _dir.y = 0;
        if (_dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * _turnSpeed);
        }


        Jump();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float speed = _dir == Vector3.zero ? 0 : _walkSpeed;
        if (_dir == Vector3.zero)
        {
            // �����̓��͂��j���[�g�����̎��́Ay �������̑��x��ێ����邾��
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        }
        else
        {
            Vector3 velo = _dir.normalized * speed;
            velo.y = _rb.velocity.y;   // �W�����v�������� y �������̑��x��ێ�����
            _rb.velocity = velo;   // �v�Z�������x�x�N�g�����Z�b�g����
        }
        _animSpeed = Mathf.Lerp(_animSpeed, speed, Time.deltaTime * 5);
    }

    void Jump()
    {
        if (IsGround() && _jumpCount > 0)
        {
            _jumpCount = 0;
        }

        Vector3 velocity = _rb.velocity;

        if (_jumpCount < _jumpMaxCount - 1)
        {
            if (Input.GetButtonDown("Jump"))
            {
                IsJump = true;
                _jumpCount++;
                velocity.y = _jumpPower;
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }
        }

        if (velocity.y > 0)
            velocity.y *= _gravityPower;

        _rb.velocity = velocity;
    }

    public bool IsGround()
    {
        Vector3 start = this.transform.position;   // start: �I�u�W�F�N�g�� Pivot
        Vector3 end = start + Vector3.down * _isGroundedLength;  // end: start ����^���̒n�_
        Debug.DrawLine(start, end, Color.red); // ����m�F�p�� Scene �E�B���h�E��Ő���\������
        bool isGrounded = Physics.Linecast(start, end); // ���������C���ɉ������Ԃ����Ă����� true �Ƃ���
        return isGrounded;
    }
}
