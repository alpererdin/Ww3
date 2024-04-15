using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tests.UITests
{
    public class FloatingText : MonoBehaviour
    {
        public float DestroyTime = 1f;
        public Vector3 Offset = new Vector3(0,2f,0);
        public Vector3 Randomize = new Vector3(0.5f,0f,0);
        private void Start()
        {
            Destroy(gameObject,DestroyTime);
            transform.localPosition += Offset;
            transform.localPosition += new Vector3(Random.Range(-Randomize.x, Randomize.x), 
                Random.Range(-Randomize.y, Randomize.y),
                Random.Range(-Randomize.z, Randomize.z));


        }
    }
    
}