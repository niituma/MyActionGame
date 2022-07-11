using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator _anim;
    PlayerController _playermove;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _playermove = GetComponent<PlayerController>();
    }

    private void LateUpdate()
    {
        _anim.SetFloat("Speed", _playermove.AnimSpeed);
        _anim.SetBool("Ground", _playermove.IsGround());
        if (_playermove.IsGround() && Input.GetButtonDown("Jump"))
        {
            _anim.SetTrigger("Jump");
            _playermove.IsJump = false;
        }
    }
}
