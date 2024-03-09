using System;
using Interfaces;
using Managers;
using Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Stages
{
    [Serializable]
    public abstract class MainStage : MonoBehaviour  
    { 
        public int _stageCount;
        public bool IsFull= false;
        public bool IsEmpty= true;
        public int stageID;
        public bool HaveEnemy = false;
        
        public GameObject CanvasObj;
        public GameObject ButtonRefPrefab;
        public Transform pos;
        public bool locked;
        private GameObject btns;
        
        private Button chill;
       
        protected abstract void Awake();
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                btns.SetActive(true);
                // UpdateStageCount(1);
            }

            if (other.CompareTag("Enemy"))
            {

                btns.SetActive(false);
                if (IsFull)
                {
                    EnemyAISignals.Instance.EnemyTrenchID?.Invoke(stageID);
                }
                // UpdateStageCount(1);
            }
            
            UpdateStageCount();
        }
        
        private void OnTriggerExit(Collider other)
        {
          //  UpdateStageCount(-1);
          UpdateStageCount();
          if (other.CompareTag("Enemy"))
          {
              if (_stageCount>0)
              {
                  _stageCount--;
              }
             

          }
        }
        protected void Btns()
        {
            float objectWidth = transform.localScale.x;  
            float xOffset = objectWidth / 2 +2f; //1f
            btns  = Instantiate(ButtonRefPrefab, transform.position+new Vector3(xOffset,1,0), Quaternion.identity,CanvasObj.transform);
            btns.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);//0.01
            btns.transform.Rotate(new Vector3(0,270f,0f));
            if (btns.transform.childCount > 0)
            {
                pos = btns.transform.GetChild(0);
                chill = btns.transform.GetChild(2).transform.gameObject.GetComponent<Button>();
                chill.onClick.AddListener(lockFnc);
            }
        }
        protected void lockFnc()
        {
            locked = !locked;
        }
        public void UpdateStageCount()//int value
        {
           
           // _stageCount += value;
            IsFull = _stageCount >= 5; //3
            IsEmpty = _stageCount == 0;
            if (IsEmpty)
            {
                HaveEnemy = false;
            }
        }
        
        
    }
}