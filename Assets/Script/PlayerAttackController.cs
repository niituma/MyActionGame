using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    InputManager _input;
    PlayerAnimController _playeranim;
    PlayerController _playercontroller;
    bool _canAttack = true;
    bool _endAttack = false;

    public bool CanAttack { get => _canAttack; }

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
        if (_input._attack)
        {
            if (_canAttack)
            {
                if (!_playercontroller.IsGround())
                {
                    _input.AttackInput(false);
                    return;
                }

                _canAttack = false;
                _playeranim.AttackAnim();
                _input.AttackInput(false);
            }
            else
            {
                _input.AttackInput(false);
                if (_endAttack) { return; }
                _playeranim.AttackAnim();
            }
        }
    }
    void AttackReady()
    {
        _canAttack = true;
        _endAttack = false;
    }

    void EndAttack()
    {
        _endAttack = true;
    }
}
