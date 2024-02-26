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
        [HideInInspector]
        public EnemyBaseState CurrentState;
        [HideInInspector]
        public int ID;
        [HideInInspector]
        public bool onFight = false;
        public bool onStage = false;//********
        [HideInInspector]
        public LayerMask playerLayer;
        [HideInInspector]
        public float Range;
        [HideInInspector]
        public ParticleSystem shootParticle;
        [HideInInspector]
        public Animator gunAnim;
        [HideInInspector]
        public Animator _anim;
        [HideInInspector]
        public EnemyBaseState _memory;
        [HideInInspector]
        public float Damage;
        
        private void OnEnable()
        {
            UnitSignals.Instance.SetUnitState += CheckId;
            UnitSignals.Instance.DeathAnimAction += SetDeathState;
        }
        protected void SetDeathState(int i)
        {
            if (ID == i)
            {
              SetUnitState(EnemyStateFactory.EnemyDeathState());
            }
        }
        protected void CheckId(int i)
        {
            if (ID == i)
            {
              //  SetUnitState(EnemyStateFactory.EnemyMoveState());
              SetUnitState(EnemyStateFactory.EnemyJumpedState());
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
            _memory = CurrentState;
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
                    //SetUnitState(EnemyStateFactory.EnemyIdleState());
                    SetUnitState(EnemyStateFactory.EnemyJumpState());
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