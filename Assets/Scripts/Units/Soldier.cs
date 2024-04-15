using Data.ScriptableObjects;
using Managers;
using Signals;
using UnityEngine;
namespace Units
{
    public class Soldier : UnitMain
    {
        [Header("DATA")]
        public SoldierData soldierData;
        private bool _soundTick;

        private TakePrefsData takaDate;
        public PlayerDataHandler.PlayerType type;
        protected override void Awake()
        {
            takaDate = FindObjectOfType<TakePrefsData>();
            if (takaDate==null)
            {
                if (soldierData != null)
                {
                    Range = soldierData.unitRange;
                    Speed = soldierData.unitSpeed;
                    Damage = soldierData.baseDamage;
                    BtnColor = soldierData.btnColor;
                    Health = soldierData.health;
                    var simulatorSpeed = shootParticle.main;
                    var emission = shootParticle.emission;
                    emission.rateOverTimeMultiplier = soldierData.shootSpeed;
                    simulatorSpeed.simulationSpeed = soldierData.bulletSpeed;
                    var shotScatter = shootParticle.shape;
                    shotScatter.angle = soldierData.shotScatter;
                    simulatorSpeed.startSpeed =soldierData.unitRange +1;
                    test = soldierData.imgg;
                }
                else
                {
                    Range = 25f;
                    Speed = 1;
                    Damage = 1f;
                    Health = 10f;
                    BtnColor = Color.blue;
                    var simulatorSpeed = shootParticle.main;
                    var emission = shootParticle.emission;
                    emission.rateOverTimeMultiplier = 0.5f;
                    simulatorSpeed.simulationSpeed = 0.5f;
                    var shotScatter = shootParticle.shape;
                    shotScatter.angle = 1f;
                    simulatorSpeed.startSpeed =25;
                }
            }
            else
            {
                takaDate.TakeUnitsData(type);
                Damage =  soldierData.baseDamage+ takaDate.Damage;
                Range  = soldierData.unitRange+takaDate.Range;
                Health  = soldierData.health+ takaDate.Health;
                var emission = shootParticle.emission;
                emission.rateOverTimeMultiplier +=  soldierData.shootSpeed+(takaDate.FireRate/10f);
                Speed = soldierData.unitSpeed;
                BtnColor = soldierData.btnColor;
                var simulatorSpeed = shootParticle.main;
                simulatorSpeed.simulationSpeed = soldierData.bulletSpeed;
                var shotScatter = shootParticle.shape;
                shotScatter.angle = soldierData.shotScatter;
                simulatorSpeed.startSpeed =soldierData.unitRange +1;
                test = soldierData.imgg;
            }
         
            
            
            ID = GetInstanceID();
        }
        private void Update()
        {
            CurrentState?.UpdateState();
           
                if (shootParticle.particleCount>0 && !_soundTick)
                {
                    _soundTick = true;
                    AudioManager.Instance.PlaySFX("shoot");
                   // UnitSignals.Instance.PlaySound?.Invoke(1,transform.position);
                   // gunAnim.SetTrigger("Fire");
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