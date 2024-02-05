using Units;
using UnityEngine;
namespace States.EnemyState
{
    public class EnemyMoveState : EnemyBaseState
    {
        public override EnemyStateType Type => EnemyStateType.Move;
        private EnemyMain _enemy;
        public override void EnterState(EnemyMain enemy)
        {
            this._enemy = enemy;
        }
        public override void UpdateState()
        {
            _enemy.transform.position += new Vector3(0, 0, -1) * Time.deltaTime * _enemy.Speed;
            if (!_enemy.onFight)
            {
                Collider[] hitColliders = Physics.OverlapSphere(_enemy.transform.position, _enemy.Range, _enemy.playerLayer);
                if (hitColliders.Length > 0)
                {_enemy.onFight = true;
                    _enemy.SetUnitState(EnemyStateFactory.EnemyFightState());
                     //true before 
                }
            }
        }
        public override void FixedUpdate() { }
        public override void ExitState() { }
    }
}