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
        private bool booleansd;
        public override void EnterState(EnemyMain enemy)
        {
            this._enemy = enemy;
            _enemy.onFight = true;
          /*  _enemy.shootParticle.Play();
            _enemy._anim.SetTrigger("IdleA");*/
          if (!_enemy._isBomber)
          {
              _enemy.shootParticle.Play();
              _enemy._anim.SetTrigger("IdleA");
          }
          else
          {
              
              _enemy._anim.SetTrigger("ThrowA");
          }
        }
        public override void UpdateState()
        {
            if (_enemy.onFight)
            {
                Collider[] hitColliders = Physics.OverlapSphere(_enemy.transform.position, _enemy.Range, _enemy.playerLayer);
                if (hitColliders.Length == 0)
                {
                  _enemy.shootParticle.transform.rotation = new Quaternion(0, -180, 0, 0);
                  _enemy.onFight = false;
                  _enemy.SetUnitState(_enemy._memory); 
                }
                if (_target == null && hitColliders.Length >0)
                {
                    randomInt = Random.Range(0, hitColliders.Length-1);
                    _target = hitColliders[randomInt].transform;
                   _enemy.shootParticle.transform.LookAt(_target.transform.position);
                }
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