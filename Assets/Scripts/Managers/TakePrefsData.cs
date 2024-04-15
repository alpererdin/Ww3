using UnityEngine;

namespace Managers
{
    public class TakePrefsData : MonoBehaviour
    {
        public PlayerDataHandler.PlayerType playerType;
        private PlayerDataHandler.PlayerData playerData;

        public int Damage;
        public int Health;
        public int Range;
        public int FireRate;

    /*    private void Start()
        {
           TakeUnitsData(playerType = PlayerDataHandler.PlayerType.Basic);
           TakeUnitsData(playerType = PlayerDataHandler.PlayerType.Machine);
           TakeUnitsData(playerType = PlayerDataHandler.PlayerType.Gunner);
        }*/

       public void TakeUnitsData(PlayerDataHandler.PlayerType type)
       {
           playerType = type;
            playerData = PlayerDataHandler.GetAllPlayerData(playerType);
            Damage = playerData.damage;
            Health = playerData.health;
            Range = playerData.range;
            FireRate = playerData.fireRate;

        /*    Debug.Log(type+"Damage: " + Damage);
            Debug.Log(type+"Health: " + Health);
            Debug.Log(type+"Range: " + Range);
            Debug.Log(type+"FireRate: " + FireRate);*/
        }
    }
}