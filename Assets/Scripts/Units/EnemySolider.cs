using Data.ScriptableObjects;
using Signals;
using UnityEngine;
namespace Units
{
    public class EnemySolider : EnemyMain
    {
        [Header("DATA")]
        public SoldierData soldierData;
        private bool _soundTick;
        protected override void Awake()
        {
            if (soldierData != null)
            {
                Range = soldierData.unitRange;
                Speed = soldierData.unitSpeed;
                Damage = soldierData.baseDamage;
                Health = soldierData.health;
                
                var simulatorSpeed = shootParticle.main;
                var emission = shootParticle.emission;
                emission.rateOverTimeMultiplier = soldierData.shootSpeed;
                simulatorSpeed.simulationSpeed = soldierData.bulletSpeed;
                var shotScatter = shootParticle.shape;
                shotScatter.angle = soldierData.shotScatter;
                simulatorSpeed.startSpeed =soldierData.unitRange+1;
            }
            else
            {
                Range = 25f;
                Speed = 1;
                Damage = 1f;
                Health = 10f;
                
                var simulatorSpeed = shootParticle.main;
                var emission = shootParticle.emission;
                emission.rateOverTimeMultiplier = 0.5f;
                simulatorSpeed.simulationSpeed = 0.5f;
                var shotScatter = shootParticle.shape;
                shotScatter.angle = 1f;
                simulatorSpeed.startSpeed =25;
            }
            ID = GetInstanceID();
        }
        private void Update()
        {
            CurrentState?.UpdateState();
            if (shootParticle.particleCount>0 && !_soundTick)
            {
                _soundTick = true;
                UnitSignals.Instance.PlaySound?.Invoke(0,transform.position);
                gunAnim.SetTrigger("Fire");
                _anim.SetTrigger("ShootA");
            }
            if (shootParticle.particleCount==0)
            {
                _soundTick = false;
            }
        }
        private void FixedUpdate()
        {
            CurrentState?.FixedUpdate();
        }
    }
}