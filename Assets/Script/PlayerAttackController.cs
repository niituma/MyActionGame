using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    InputManager _input;
    PlayerAnimController _playeranim;
    PlayerController _playercontroller;
    bool _isattack = false;

    public bool Isattack { get => _isattack;}

    // Start is called before the first frame update
    void Start()
    {
        _playercontroller = GetComponent<PlayerController>();
        _playeranim = GetComponent<PlayerAnimController>();
        _input = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isattack) { _input.AttackInput(false); }

        if (_input._attack && !_isattack)
        {
            if (!_playercontroller.IsGround())
            {
                _input.AttackInput(false);
                return;
            }

            _isattack = true;
            _playeranim.AttackAnim();
            _input.AttackInput(false);
        }
    }
    void AttackReady()
    {
        _isattack = false;
    }
}
