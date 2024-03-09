using Signals;
using Stages;
using Units;
using UnityEngine;
namespace States
{
    public class MoveState : BaseState
    { 
        public override UnitStateType Type => UnitStateType.Move;
        private UnitMain _unit;
        public override void EnterState(UnitMain unit)
        {
            this._unit = unit;
            _unit.onStage = false;
            _unit._anim.SetTrigger("RunA");
        }
        public override void UpdateState()
        {
            
            if (_unit.CurrentState.Type!=UnitStateType.Move)
            {
                _unit.SetUnitState(UnitStateFactory.MoveState());
            }
            _unit.transform.position += new Vector3(0, 0, 1) * Time.deltaTime * _unit.Speed;
            Collider[] hitColliders = Physics.OverlapSphere(_unit.transform.position, _unit.Range, _unit.enemyLayer);
            if (hitColliders.Length > 0 )
            { 
                _unit.SetUnitState(UnitStateFactory.FightState());
            }
        }
        public override void FixedUpdate() { }
        public override void ExitState() { }
    }
}