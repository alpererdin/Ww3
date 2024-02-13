using Signals;
using States.EnemyState;
using UnityEngine;
namespace Units
{
     
    public class EnemySolider : EnemyMain
    {
        public int unitSpeed;
        public float shootSpeed=.5f;
        public float bulletSpeed=.5f;
        
        private bool _soundTick;
        protected override void Awake()
        {
            Speed = unitSpeed;
            ID = GetInstanceID();
            var simulatorSpeed = shootParticle.main;
            var emission = shootParticle.emission;
            emission.rateOverTimeMultiplier = shootSpeed;
            simulatorSpeed.simulationSpeed = bulletSpeed;
        }
        private void Update()
        {
            CurrentState?.UpdateState();
            if (shootParticle.particleCount>0 && !_soundTick)
            {
                // Debug.Log(shoot);
                _soundTick = true;
                UnitSignals.Instance.PlaySound?.Invoke(0,transform.position);
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