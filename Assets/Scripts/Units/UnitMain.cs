using System;
using Signals;
using Stages;
using States;
using UnityEngine;
namespace Units
{
    [Serializable]
    public abstract class UnitMain :MonoBehaviour
    {
        internal int Speed; 
        public BaseState CurrentState;
        public int ID;
        protected Color BtnColor;
        private void OnEnable()
        {
            UnitSignals.Instance.SetUnitState += CheckId;
        }
        protected void CheckId(int i)
        {
            if (ID == i)
            {
                SetUnitState(UnitStateFactory.MoveState());
            }
        }
        protected abstract void Awake();
        protected virtual void Start()
        {
            if (CurrentState == null)
            {
                SetUnitState(UnitStateFactory.MoveState());
            }
        }
        public void SetUnitState(BaseState newState)
        {
            CurrentState?.ExitState();
            CurrentState = newState;
            CurrentState.EnterState(this);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Trench"))
            {
                if (other.GetComponent<StageTypeOne>()._stageCount<3 && other.GetComponent<StageTypeOne>().locked==false)
                {
                    UnitSignals.Instance.OnUnitID?.Invoke(ID,BtnColor,other.GetComponent<StageTypeOne>().pos);
                    SetUnitState(UnitStateFactory.IdleState());
                }
              
            }
        }
    } 
}