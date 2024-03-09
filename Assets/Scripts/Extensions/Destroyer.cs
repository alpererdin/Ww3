using System;
using UnityEngine;

namespace Extensions
{
    public class Destroyer : MonoBehaviour
    {
        public float _clc = 2;

        private void Start()
        {
            Destroy(gameObject,_clc);
        }
    }
}