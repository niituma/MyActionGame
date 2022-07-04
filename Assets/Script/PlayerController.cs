using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpPower = 5f;
    [SerializeField] float _isGroundedLength = 1.1f;
    [SerializeField] float _gravityPower = 0.93f;
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

        _dir = Camera.main.transform.TransformDirection(_dir);
        // カメラは斜め下に向いているので、Y 軸の値を 0 にして「XZ 平面上のベクトル」にする
        _dir.y = 0;
        Move();
        Jump();
    }
    private void FixedUpdate()
    {

    }
    void Move()
    {
        float speed = _dir == Vector3.zero ? 0 : _speed;
        if (_dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        }
        else
        {
            Vector3 velo = _dir.normalized * speed;
            velo.y = _rb.velocity.y;   // ジャンプした時の y 軸方向の速度を保持する
            _rb.velocity = velo;   // 計算した速度ベクトルをセットする
        }

    }

    void Jump()
    {
        Vector3 velosity = _rb.velocity;

        if (IsGround())
        {
            if (Input.GetButtonDown("Jump"))
            {
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }
            else if (velosity.y > 0)
                velosity.y *= _gravityPower;
        }

        _rb.velocity = velosity;
    }

    bool IsGround()
    {
        Vector3 start = this.transform.position;   // start: オブジェクトの Pivot
        Vector3 end = start + Vector3.down * _isGroundedLength;  // end: start から真下の地点
        Debug.DrawLine(start, end); // 動作確認用に Scene ウィンドウ上で線を表示する
        bool isGrounded = Physics.Linecast(start, end); // 引いたラインに何かがぶつかっていたら true とする
        return isGrounded;
    }
}
