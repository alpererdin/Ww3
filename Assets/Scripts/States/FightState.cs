using Units;
using UnityEngine;



namespace States
{
    public class FightState : BaseState
    {
        public override UnitStateType Type => UnitStateType.Fight;
        private UnitMain _unit;
        int t;
        private Transform _target;
        private UnitStateType memory;
        public override void EnterState(UnitMain unit)
        {
            this._unit = unit;
            _unit.onFight = true;
            _unit.shootParticle.Play();
        }
        public override void UpdateState()
        {
            if (_unit.onFight)
            {
                Collider[] hitColliders = Physics.OverlapSphere(_unit.transform.position, _unit.Range, _unit.enemyLayer);
                if (hitColliders.Length == 0)
                {
                    //CHANCE TO _UNİT.TRANSFORM.ROTATİON***********************************
                   // _unit.transform.rotation = new Quaternion(0, 0, 0, 0);
                    _unit.shootParticle.transform.rotation = new Quaternion(0, 0, 0, 0);
                   // _unit.SetUnitState(UnitStateFactory.MoveState());
                   _unit.onFight = false;
                    _unit.SetUnitState(_unit.memory);     //??????
                }
                if (_target == null && hitColliders.Length >0)
                {
                    t = Random.Range(0, hitColliders.Length-1);
                    _target = hitColliders[t].transform;
                   // _unit.transform.LookAt(_target.transform.position);
                   _unit.shootParticle.transform.LookAt(_target.transform.position);
                }

                if (!_unit && !_target)
                {
                    _unit.shootParticle.transform.LookAt(_target.transform.position);
                }
               
            }
        }
        public override void FixedUpdate() { }

        public override void ExitState()
        {
            _unit.shootParticle.Stop();
        }
    }
}
