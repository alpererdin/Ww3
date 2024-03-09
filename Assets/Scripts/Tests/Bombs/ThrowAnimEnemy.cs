using System;
using System.Collections;
using System.Collections.Generic;
using Signals;
using Units;
using UnityEngine;
public class ThrowAnimEnemy : MonoBehaviour
{
    private int idParent;
    private Transform getOnce;
    private Transform _current;
    private void Start()
    {
        idParent = GetComponentInParent<EnemySolider>().GetInstanceID();
    }

    public void TriggerEvent()
    {
        UnitSignals.Instance.Throwbomb?.Invoke(idParent);
     
    }

    
}
