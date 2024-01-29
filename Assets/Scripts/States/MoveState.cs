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
            //Debug.Log("enter moveState");
        }

        public override void UpdateState()
        {
            _unit.transform.position += new Vector3(0, 0, 1) * Time.deltaTime * _unit.Speed;
        }

        public override void FixedUpdate()
        {
        }

        public override void ExitState()
        {
           // Debug.Log("exit moveState");
        }
    }
}