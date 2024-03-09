using UnityEngine;
using UnityEngine.UI;

namespace Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SoldierData", menuName = "UnitData/SoldierData", order = 0)]
    public class SoldierData : ScriptableObject
    {
        public float baseDamage = 1;
        public int unitSpeed;
        public float shootSpeed = 0.5f;
        public float bulletSpeed = 0.5f;
        public float shotScatter = 1; // basic = 1 | gunner = 0.1 | machine = 0.5
        public float unitRange = 25f;
        public Color btnColor = Color.blue;
        public float coolDownTime;
        
        
        public float health;
        
        //
       /* public int currentUpgradeLevel = 0;
        public float upgradeMultiplier = 1.2f; 
        public int maxUpgradeLevel = 5; 
        
        public float GetCurrentDamage()
        {
            return baseDamage * Mathf.Pow(upgradeMultiplier, currentUpgradeLevel);
        }
        //*/
       
        public Sprite imgg;
      

    }
}