using System;
using System.Collections.Generic;
using Signals;
using Stages;
using States;
using Unity.Mathematics;
using UnityEngine;
namespace Units
{
    [Serializable]
    public abstract class UnitMain :MonoBehaviour
    {
        internal int Speed; 
        [HideInInspector]
        public BaseState CurrentState;
        [HideInInspector]
        public int ID;
        [HideInInspector]
        public Color BtnColor;
        [HideInInspector]
        public Sprite test;
        [HideInInspector]
        public bool onFight = false;
        [HideInInspector]
        public bool onStage = false;
        [HideInInspector]
        public float Range;
      //  [HideInInspector]
        public LayerMask enemyLayer;
       // [HideInInspector]
        public ParticleSystem shootParticle;
        //[HideInInspector]
        public Animator _anim;
        [HideInInspector]
        public BaseState memory;  
        [HideInInspector]
        public float Damage;
        [HideInInspector]
        public GameObject currentStage;
        //update This
        public bool _isBomber=false;
        public GameObject bombPrefab;
        //[HideInInspector]
        public float forceMagnitude = 0.0003f;
        [HideInInspector]
        public float Health;
        
        private void OnEnable()
        {
            UnitSignals.Instance.SetUnitState += CheckId;
            UnitSignals.Instance.DeathAnimAction += SetDeathState;
            UnitSignals.Instance.Throwbomb += throwFunc;
        }
        protected void SetDeathState(int i)
        {
            if (ID == i)
            {
                SetUnitState(UnitStateFactory.DeathState());
            }
        }
        protected void CheckId(int i)
        {
            if (ID == i)
            {
               SetUnitState(UnitStateFactory.JumpedState());
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
            memory = CurrentState;
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
                    currentStage = other.gameObject;
                    UnitSignals.Instance.OnUnitID?.Invoke(ID, test, stage.pos, other.gameObject);
                    SetUnitState(UnitStateFactory.JumpState());
                }
                else
                {
                    Debug.Log("passed");
                    // passState or null
                }
            }
        }
       public bool IsTrenchCollider(Collider collider)
        {
            return collider.CompareTag("Trench");
        }
        public bool CanEnterTrench(StageTypeOne stage)
        {
            //3
            return stage._stageCount < 5 && !stage.locked;
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
                        Vector3 forwardForce = transform.GetChild(0).transform.forward * forceMagnitude;  
                        Vector3 upwardForce = Vector3.up * forceMagnitude; 
                        Vector3 totalForce = forwardForce + upwardForce; 
                        rb.AddForce(totalForce, ForceMode.Impulse);
                    }
                    else
                    {
                        Debug.LogWarning("rb not found");
                    }
                }
            }
          
        }
        private void OnDisable()
        {
            UnitSignals.Instance.SetUnitState -= CheckId;
            UnitSignals.Instance.DeathAnimAction -= SetDeathState;
            UnitSignals.Instance.Throwbomb -= throwFunc;
        }
    } 
}
