using System;
using Managers;
using Signals;
using UnityEngine;

namespace Stages
{
    public class StageTypeOne : MainStage
    {
        protected override void Awake()
        {
            CanvasObj= GameObject.FindWithTag("Canvas").gameObject;
            stageID = GetInstanceID();
            Btns();
        }
     
    }
}