using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSword : MonoBehaviour
{
    [SerializeField]
    GameObject _HitEff;
    [SerializeField]
    string _hitObjTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _hitObjTag)
        {
            Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
            Instantiate(_HitEff, hitPos, Quaternion.identity);
        }
    }
}
