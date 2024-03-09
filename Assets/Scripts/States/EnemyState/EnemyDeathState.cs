using Stages;
using Units;

namespace States.EnemyState
{
    public class EnemyDeathState : EnemyBaseState
    {
        public override EnemyStateType Type => EnemyStateType.Death;
        private EnemyMain _enemy;
        public override void EnterState(EnemyMain enemy)
        {
            this._enemy = enemy;
            _enemy._anim.SetTrigger("DeathA");
            
            if (_enemy.currentStage != null)
            {
                _enemy.currentStage.GetComponent<StageTypeOne>()._stageCount--;
            }
        }
        public override void UpdateState() { }

        public override void FixedUpdate() {  }
        public override void ExitState() { }
        
    }
}