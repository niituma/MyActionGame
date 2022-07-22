using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPController : MonoBehaviour
{
    [SerializeField]
    bool _godMode = false;

    [SerializeField]
    Slider _HPSlider;

    [SerializeField]
    float _maxHP = 200f;

    float _currentHP = 0f;

    [SerializeField]
    bool _damege = false;

    private void Awake()
    {
        _currentHP = _maxHP;
    }

    private void Update()
    {
        if (_damege)
        {
            Damage(10);
            _damege = false;
        }
    }
    public void Damage(int damage)
    {
        if (_godMode) { return; }

        _currentHP -= damage;

        _HPSlider.value = _currentHP/ _maxHP;
    }

    public void Heel(int heel)
    {
        if (_godMode) { return; }

        _currentHP = Mathf.Min(heel, _currentHP + heel);

        _HPSlider.value = _currentHP / _maxHP;
    }
}
