using System;
using Signals;
using UnityEngine;
namespace Stages
{
    [Serializable]
    public abstract class MainStage : MonoBehaviour
    { 
        public int _stageCount;
        public bool IsFull= false;
        public bool IsEmpty= true;
        protected int stageID;
        protected abstract void Awake();
        
        private void OnTriggerEnter(Collider other)
        {
            UpdateStageCount(1);
        }
        private void OnTriggerExit(Collider other)
        {
            UpdateStageCount(-1);
        }
        public void UpdateStageCount(int value)
        {
            _stageCount += value;
            if (_stageCount < 3)
            { 
                IsFull = false;
            }
            else
            { 
                IsFull = true;
            }

            if (_stageCount==0)
            {
                IsEmpty = true;
            }
            else
            {
                IsEmpty = false;
            }
        }
    }
}