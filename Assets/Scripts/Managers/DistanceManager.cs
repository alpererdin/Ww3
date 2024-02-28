using System;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class DistanceManager : MonoBehaviour
    {
        public Slider _Slider;
        public Terrain terrain;
        private Vector3 terrainCenter;
        private float terrainLength;
        void Start()
        {
            Vector3 terrainSize = terrain.terrainData.size;
            Vector3 terrainCenter = terrain.transform.position + terrainSize / 2f;
            transform.position = new Vector3(transform.position.x, transform.position.y, terrainCenter.z);
            
            _Slider.value = 0.5f;
            
            terrainLength = terrainSize.z;
        }

       /* private void Update()
        {
            SliderValueFnc(transform.position.z);
        }*/
        private void OnTriggerStay(Collider other)
       {
           if (other.CompareTag("Player"))
           {
               transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z);
               SliderValueFnc(transform.position.z);
           }
           if (other.CompareTag("Enemy"))
           {
               transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z);
               SliderValueFnc(transform.position.z);
           }
       }
       void SliderValueFnc(float objZ)
       {
           float normalizedPosition = (objZ - terrainCenter.z + terrainLength / 2f) / terrainLength;
           _Slider.value = normalizedPosition;
       }
    }
}