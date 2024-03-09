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
        [HideInInspector]
        public bool onStage = false;//********
      //  [HideInInspector]
        public LayerMask playerLayer;
        [HideInInspector]
        public float Range;
     //   [HideInInspector]
        public ParticleSystem shootParticle;
        [HideInInspector]
        public Animator gunAnim;
        [HideInInspector]
        public Animator _anim;
        [HideInInspector]
        public EnemyBaseState _memory;
        [HideInInspector]
        public float Damage;
        [HideInInspector]
        public GameObject currentStage;
        [HideInInspector]
        public int currentStageID;
        [HideInInspector]
        public float Health;
        
        public bool _isBomber=false;
        public GameObject bombPrefab;
        
        public float forceMagnitude = 0.0003f;
        private void OnEnable()
        {
            UnitSignals.Instance.SetUnitState += CheckId;
            UnitSignals.Instance.DeathAnimAction += SetDeathState;
            EnemyAISignals.Instance.EnemyTrenchID += EnemySignTest;
            UnitSignals.Instance.Throwbomb += throwFunc;
        }
        private void throwFunc(int z)
        {
            if (_isBomber)
            {
                if (ID == z)
                {
                    GameObject go = Instantiate(bombPrefab, transform.GetChild(0).transform.position , transform.GetChild(0).transform.rotation);
                    Rigidbody rb = go.GetComponent<Rigidbody>();  
                    if (rb != null)
                    {
                        Vector3 forwardForce = transform.GetChild(0).transform.forward * forceMagnitude ;  
                        Vector3 upwardForce = Vector3.up * forceMagnitude; 
                        Vector3 totalForce = forwardForce + upwardForce; 
                        rb.AddForce(totalForce, ForceMode.Impulse);
                        Debug.Log("fnc calisir");
                    }
                    else
                    {
                        Debug.LogWarning("Rigidbody component not found on instantiated bombPrefab.");
                    }
                }
            }
        }

        private void EnemySignTest(int arg0)
        {
            if (currentStageID==arg0 && CurrentState.Type == EnemyStateType.Idle)
            {
                SetUnitState(EnemyStateFactory.EnemyJumpedState());
            }
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
                currentStage = other.gameObject;
                StageTypeOne stage = other.GetComponent<StageTypeOne>();

                if (CanEnterTrench(stage))
                {
                    currentStageID = stage.stageID;
                    //EnemyAISignals.Instance.EnemyTrenchID?.Invoke(stage.stageID);
                    
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
            return stage._stageCount < 5 && !stage.locked;
        } 
    } 
}