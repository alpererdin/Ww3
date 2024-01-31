using System;
using Interfaces;
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
        protected int stageID;
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
                // UpdateStageCount(1);
            }
            
            UpdateStageCount();
        }
        private void OnTriggerExit(Collider other)
        {
          //  UpdateStageCount(-1);
          UpdateStageCount();
        }
        protected void Btns()
        {
            btns  = Instantiate(ButtonRefPrefab, transform.position+new Vector3(5.5f,0,0), Quaternion.identity,CanvasObj.transform);

            btns.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            btns.transform.Rotate(new Vector3(0f,270f,0f));
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
            IsFull = _stageCount >= 3;
            IsEmpty = _stageCount == 0;
            if (IsEmpty)
            {
                HaveEnemy = false;
            }
        }
    }
}