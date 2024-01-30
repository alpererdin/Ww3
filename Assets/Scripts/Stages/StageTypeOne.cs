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
            stageID = GetInstanceID();
            Btns();
        }
    }
}