using System;
using Managers;
using Signals;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Stages
{
    public class StageTypeOne : MainStage
    {
        private void OnEnable()
        {
            GameSignals.Instance.TakeCanvasObj += TakeCanvas;
        }
        private void OnDisable()
        {
            GameSignals.Instance.TakeCanvasObj -= TakeCanvas;
        }
        protected override void Awake()
        {
           //CanvasObj= GameObject.FindWithTag("Canvas").gameObject;
            stageID = GetInstanceID();
        }
        protected void TakeCanvas()
        {
            
            CanvasObj= GameObject.FindWithTag("Canvas").gameObject;
            Btns();
        }
     
    }
}