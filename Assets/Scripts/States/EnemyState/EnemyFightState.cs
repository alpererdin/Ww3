using Units;
using UnityEngine;
namespace States.EnemyState
{
    public class EnemyFightState : EnemyBaseState
    {
        public override EnemyStateType Type => EnemyStateType.Fight;
        private EnemyMain _enemy;
        int randomInt;
        private Transform _target;
        private EnemyStateType _memory;
        
        public override void EnterState(EnemyMain enemy)
        {
            this._enemy = enemy;
            _enemy.onFight = true;
            _enemy.shootParticle.Play();
            _enemy._anim.SetTrigger("IdleA");
        }
        public override void UpdateState()
        {
            if (_enemy.onFight)
            {
                Collider[] hitColliders = Physics.OverlapSphere(_enemy.transform.position, _enemy.Range, _enemy.playerLayer);
                if (hitColliders.Length == 0)
                {
                   
                  //  _enemy.transform.rotation = new Quaternion(0, 0, 0, 0);
                  _enemy.shootParticle.transform.rotation = new Quaternion(0, -180, 0, 0);
                  _enemy.onFight = false;
                  _enemy.SetUnitState(_enemy._memory); 
                   // 18:54,  _enemy.SetUnitState(EnemyStateFactory.EnemyMoveState());
                    //false before 
                }
                if (_target == null && hitColliders.Length >0)
                {
                    randomInt = Random.Range(0, hitColliders.Length-1);
                    _target = hitColliders[randomInt].transform;
                  //  Vector3 targetDirection = _enemy.transform.position - _target.position;
                   // _enemy.transform.rotation = Quaternion.LookRotation(targetDirection.normalized);
                   //_enemy.shootParticle.transform.rotation = Quaternion.LookRotation(targetDirection.normalized);
                   _enemy.shootParticle.transform.LookAt(_target.transform.position);
                }
                // if units range shorter then enemy  -->
                if (_enemy.shootParticle != null && _target != null)
                {
                    _enemy.shootParticle.transform.LookAt(_target.transform.position);
                }
                
            }
        }
        public override void FixedUpdate() { }
        public override void ExitState()
        {
            _enemy.shootParticle.Stop();
        }
        
        
    }
}