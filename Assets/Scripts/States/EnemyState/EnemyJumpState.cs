using Units;
using UnityEngine;
namespace States.EnemyState
{
    public class EnemyJumpState : EnemyBaseState
    {
        public override EnemyStateType Type => EnemyStateType.Jump;
        private EnemyMain _enemy;
        public override void EnterState(EnemyMain enemy)
        {
            this._enemy = enemy;
            _enemy._anim.SetTrigger("JumpA");
            _enemy.onStage = true;
        }

        public override void UpdateState()
        {
         
        }
        public override void FixedUpdate()
        {
            
            if (_enemy.transform.position.y > 0.75f)
            {
                _enemy.transform.position += new Vector3(0, -0.1f, -0.8f) * Time.deltaTime * _enemy.Speed;
            }
            if (_enemy.transform.position.y < 0.76 || _enemy.transform.position.y < 0.86)
            {
                _enemy.SetUnitState(EnemyStateFactory.EnemyIdleState());
            }
        }
        public override void ExitState() { }
    }
    public class EnemyJumpedState: EnemyBaseState
    {
        public override EnemyStateType  Type => EnemyStateType.Jumped;
        private EnemyMain _enemy;
        public override void EnterState(EnemyMain enemy)
        {
            this._enemy = enemy;
            _enemy._anim.SetTrigger("JumpA");
            _enemy.currentStage = null;
            
            _enemy.onStage = false;
        }

        public override void UpdateState() { }
        public override void FixedUpdate()
        {
            if (_enemy.transform.position.y < 1.06f)//1.06
            {
                _enemy.transform.position += new Vector3(0, 0.1f, 0) * Time.deltaTime * _enemy.Speed;// ? z : +0.5
            }
            if (_enemy.transform.position.y == 1.05f)
            {
             /*   var transform = _enemy.transform;
                var position = transform.position;
                position= new Vector3(position.x,1.05f,position.z);
                transform.position = position;*/
                _enemy.SetUnitState(EnemyStateFactory.EnemyMoveState());
            } 
        }
        public override void ExitState() { }
    }
}