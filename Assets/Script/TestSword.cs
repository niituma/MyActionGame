using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSword : MonoBehaviour
{
    [SerializeField]
    GameObject _HitEff;
    private void OnTriggerEnter(Collider other)
    {
        Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
        Instantiate(_HitEff, hitPos,Quaternion.identity);
    }
}
