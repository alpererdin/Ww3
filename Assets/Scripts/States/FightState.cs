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
        public override void EnterState(UnitMain unit)
        {
            this._unit = unit;
            _unit.shootParticle.Play();
        }
        public override void UpdateState()
        {
            if (_unit.onFight)
            {
                Collider[] hitColliders = Physics.OverlapSphere(_unit.transform.position, _unit.Range, _unit.enemyLayer);
                if (hitColliders.Length == 0)
                {
                    _unit.transform.rotation = new Quaternion(0, 0, 0, 0);
                    _unit.SetUnitState(UnitStateFactory.MoveState());
                    _unit.onFight = false; //false before 
                }
                if (_target == null && hitColliders.Length >0)
                {
                    t = Random.Range(0, hitColliders.Length-1);
                    _target = hitColliders[t].transform;
                    _unit.transform.LookAt(_target.transform.position);
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