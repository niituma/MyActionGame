using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    InputManager _input;
    PlayerAnimController _playeranim;
    bool _isattack = false;
    // Start is called before the first frame update
    void Start()
    {
        _playeranim = GetComponent<PlayerAnimController>();
        _input = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isattack) { _input.AttackInput(false); }

        if (_input._attack && !_isattack)
        {
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
