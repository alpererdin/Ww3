using Units;
using UnityEngine;
namespace States
{
    public class JumpState: BaseState
    {
        public override UnitStateType Type => UnitStateType.Jump;
        private UnitMain _unit;
   
        public override void EnterState(UnitMain unit)
        {
            this._unit = unit;
            _unit._anim.SetTrigger("JumpA");
            _unit.onStage = true;
            // _unit.Range += 1; 
            _unit.Damage += 2; 
     
        }
        public override void UpdateState() {}
        public override void FixedUpdate()
        {
            if (_unit.transform.position.y > 0.75f)
            {
                _unit.transform.position += new Vector3(0, -0.1f, 0.8f) * Time.deltaTime * _unit.Speed;
            }
            if (_unit.transform.position.y < 0.76 || _unit.transform.position.y < 0.86)
            {
                _unit.SetUnitState(UnitStateFactory.IdleState());
            }
        }
        public override void ExitState() { }
    }
    public class JumpedState: BaseState
    {
        public override UnitStateType Type => UnitStateType.Jumped;
        private UnitMain _unit;
        public override void EnterState(UnitMain unit)
        {
            this._unit = unit;
            _unit._anim.SetTrigger("JumpA");
            _unit.onStage = false;
            //_unit.Range -= 1;
            _unit.Damage -= 2;
            
            _unit.currentStage = null;
            
        }
        public override void UpdateState() { }
        public override void FixedUpdate()
        {
            if (_unit.transform.position.y < 1.06f)
            {
                _unit.transform.position += new Vector3(0, 0.1f, 0) * Time.deltaTime * _unit.Speed;// ? z : +0.5
            }
            if (_unit.transform.position.y == 1.05f)
            {
                _unit.SetUnitState(UnitStateFactory.MoveState());
            }
        }
        public override void ExitState()
        { }
    }
}