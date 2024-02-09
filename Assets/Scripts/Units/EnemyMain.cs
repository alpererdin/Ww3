using System;
using Signals;
using Stages;
using States;
using States.EnemyState;
using UnityEngine;
namespace Units
{
    [Serializable]
    public abstract class EnemyMain :MonoBehaviour
    {
        internal int Speed; 
        public EnemyBaseState CurrentState;
        public int ID;
        public bool onFight = false;
        public LayerMask playerLayer;
        public float Range;
        public ParticleSystem shootParticle;
        private void OnEnable()
        {
            UnitSignals.Instance.SetUnitState += CheckId;
        }
        protected void CheckId(int i)
        {
            if (ID == i)
            {
                SetUnitState(EnemyStateFactory.EnemyMoveState());
            }
        }
        protected abstract void Awake();
        protected virtual void Start()
        {
            if (CurrentState == null)
            {
                SetUnitState(EnemyStateFactory.EnemyMoveState());
            }
        }
        public void SetUnitState(EnemyBaseState newState)
        {
            CurrentState?.ExitState();
            CurrentState = newState;
            CurrentState.EnterState(this);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (IsTrenchCollider(other))
            {
                StageTypeOne stage = other.GetComponent<StageTypeOne>();

                if (CanEnterTrench(stage))
                {
                    stage._stageCount++;
                    stage.HaveEnemy=true;
                    //UnitSignals.Instance.OnUnitID?.Invoke(ID, BtnColor, stage.pos, other.gameObject);
                    SetUnitState(EnemyStateFactory.EnemyIdleState());
                }
            }
        }
        private bool IsTrenchCollider(Collider collider)
        {
            return collider.CompareTag("Trench");
        }
        private bool CanEnterTrench(StageTypeOne stage)
        {
            return stage._stageCount < 3 && !stage.locked;
        } 
    } 
}