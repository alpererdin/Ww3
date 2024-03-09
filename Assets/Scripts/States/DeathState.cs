using Stages;
using Units;

namespace States
{
    public class DeathState : BaseState
    {
        public override UnitStateType Type => UnitStateType.Death;
        private UnitMain _unit;
        public override void EnterState(UnitMain unit)
        {
            this._unit = unit;
            //_unit.onDeath = true;
            _unit._anim.SetTrigger("DeathA");
            if (_unit.currentStage != null)
            {
                _unit.currentStage.GetComponent<StageTypeOne>()._stageCount--;
            }
        }
        public override void UpdateState() { }

        public override void FixedUpdate() { }
        public override void ExitState() { }
        
    }
}