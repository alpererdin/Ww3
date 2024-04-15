using System;
using Signals;
using UnityEngine;

namespace Extensions
{
    public class Destroyer : MonoBehaviour
    {
        public float _clc = 2;

        private void Start()
        {
            //UnitSignals.Instance.PlaySound?.Invoke(2,transform.position);
            Destroy(gameObject,_clc);
        }

        //14.03
        private void OnDisable()
        {
            Destroy(gameObject);
        }
       
    }
}