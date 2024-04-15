using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Managers
{
    public class DistanceManager : MonoBehaviour
    {
        public Slider _Slider;
        private float middleZ;
        public GameObject findobj;
        public GameObject objOne, objTwo;
       
        void Start()
        {
            findobj=GameObject.FindGameObjectWithTag("DistanceSlider");
            _Slider = findobj.GetComponent<Slider>();
            objOne = GameObject.FindGameObjectWithTag("Finish");
            objTwo = GameObject.FindGameObjectWithTag("EnemyFinish");
            
             middleZ = (objOne.transform.position.z + objTwo.transform.position.z) / 2f;
            Vector3 middlePosition = new Vector3(objOne.transform.position.x, objOne.transform.position.y, middleZ);
            transform.position = middlePosition;
            _Slider.value = 0.5f;
        }
        private void OnTriggerStay(Collider other)
       {
           if (other.CompareTag("Player") || other.CompareTag("Enemy"))
           {
               transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z);
               float middleZ = (objOne.transform.position.z + objTwo.transform.position.z) / 2f;
               SliderValueFnc(middleZ);
           }
       }
        void SliderValueFnc(float objZ)
        {
            float normalizedPosition = (transform.position.z - middleZ + (objTwo.transform.position.z - objOne.transform.position.z) / 2f) / (objTwo.transform.position.z - objOne.transform.position.z);
            _Slider.value = normalizedPosition;
        }
    }
}