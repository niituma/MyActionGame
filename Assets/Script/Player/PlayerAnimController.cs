using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    Animator _anim;
    PlayerMoveController _playermove;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _playermove = GetComponent<PlayerMoveController>();
    }

    private void LateUpdate()
    {
        _anim.SetFloat("Speed", _playermove.AnimSpeed);
        _anim.SetBool("Ground", _playermove.IsGround());
        _anim.SetFloat("StateTime", Mathf.Repeat(_anim.GetCurrentAnimatorStateInfo(0).normalizedTime, 1f));
    }

    /// <summary>
    /// Jumpのアニメーションをする
    /// </summary>
    public void JumpAnim()
    {
        _anim.SetTrigger("Jump");
    }

    public void AttackAnim()
    {
        _anim.SetTrigger("Attack");
    }
}
