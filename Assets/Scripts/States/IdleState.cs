using Units;
using UnityEngine;
namespace States
{
    public class IdleState : BaseState
    {
        public override UnitStateType Type => UnitStateType.Idle;
        private UnitMain _unit;
        public override void EnterState(UnitMain unit)
        {
            this._unit = unit;
            _unit._anim.SetTrigger("IdleA");
        }
        public override void UpdateState()
        {
            if (!_unit.onFight )
            {
                Collider[] hitColliders = Physics.OverlapSphere(_unit.transform.position, _unit.Range, _unit.enemyLayer);
                if (hitColliders.Length > 0)
                {
                    _unit.SetUnitState(UnitStateFactory.FightState());
                }
            }
        }
        public override void FixedUpdate() { }
        public override void ExitState() { }
    }
}
