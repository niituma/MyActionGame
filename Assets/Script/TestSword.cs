using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestSword : MonoBehaviour
{
    [SerializeField]
    GameObject _HitEff;
    [SerializeField]
    string _hitObjTag;
    PlayerMoveController _player;
    private void Start()
    {
        _player = FindObjectOfType<PlayerMoveController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _hitObjTag)
        {
            Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
            Instantiate(_HitEff, hitPos, Quaternion.identity);
            OnAttackHit();
        }
    }
    public void OnAttackHit()
    {
        var _anim = _player.GetComponent<Animator>();
        _anim.speed = 0f;

        var seq = DOTween.Sequence();
        seq.SetDelay(0.1f);
        // モーションを再開
        seq.AppendCallback(() => _anim.speed = 1f);
    }
}
