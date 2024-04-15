using System;
using System.Collections.Generic;
using Interfaces;
using Managers;
using Signals;
using Units;
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
        private bool playerfirstTime=false;
        private bool enemyfirstTime=false;
        protected abstract void Awake();
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                btns.SetActive(true);
                if (!playerfirstTime)
                {
                    playerfirstTime = true;
                    ScoreBoardSignals.Instance.OnTrenchTaken?.Invoke();
                }
                
            }
            if (other.CompareTag("Enemy"))
            {
                btns.SetActive(false);
               if (IsFull)
                {
                    // test edilmedi
                    AudioManager.Instance.PlaySFX("whistle");
                    // ****
                    EnemyAISignals.Instance.EnemyTrenchID?.Invoke(stageID);
                }
                if (!enemyfirstTime)
                {
                   enemyfirstTime = true;
                   ScoreBoardSignals.Instance.OnEnemyTrenchTaken?.Invoke();
                }
            }
            
            UpdateStageCount();
        }
        protected void Btns()
        {
            float objectWidth = transform.localScale.x;  
            float xOffset = objectWidth / 2 ; //+1f
            float xOffsetNew = objectWidth / 2 ; //+1f
            float yOffset = 2 ; //+1f
            btns  = Instantiate(ButtonRefPrefab, transform.position+new Vector3(-xOffsetNew,yOffset,0), Quaternion.identity,CanvasObj.transform);//y=0.85f
            btns.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);//0.01
            btns.transform.Rotate(new Vector3(0,270f,0f));
            if (btns.transform.childCount > 0)
            {
                pos = btns.transform.GetChild(0).GetChild(0);
                chill = btns.transform.GetChild(2).GetChild(0).transform.gameObject.GetComponent<Button>();
                chill.onClick.AddListener(lockFnc);
            }
        }
        protected void lockFnc()
        {
            locked = !locked;
        }
        public void UpdateStageCount()//int value
        {
            IsFull = _stageCount >= 5; //3
            IsEmpty = _stageCount == 0;
            if (IsEmpty)
            {
                HaveEnemy = false;
            }
        }
    }
}