using UnityEngine;
using Data.ScriptableObjects;

namespace Managers
{
    public class UpgradeSystem : MonoBehaviour
    {
        public void UpgradeSoldier(SoldierData soldierData)
        {
          /*  if (soldierData.currentUpgradeLevel < soldierData.maxUpgradeLevel)
            {
                soldierData.currentUpgradeLevel++;
                Debug.Log($"{soldierData.name} upgraded to level {soldierData.currentUpgradeLevel}");
                soldierData.baseDamage *= soldierData.upgradeMultiplier;
            }
            else
            {
                Debug.Log($"{soldierData.name} has reached the maximum upgrade level.");
            }*/
        }
    }
}