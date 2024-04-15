using System;
using Data.ScriptableObjects;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
  /*  public SoldierData basicData;
    public SoldierData machineData;
    public SoldierData gunnerData;
    public SoldierData bomberData;
    private PlayerDataHandler.PlayerData playerData;
    private void Awake()
    {
        playerData = new PlayerDataHandler.PlayerData();
        
        playerData.damage = (int)basicData.baseDamage;
        playerData.health = (int)basicData.health;
        playerData.range = (int)basicData.unitRange;
        SetPlayerData(PlayerType.Basic, PlayerUpgradeSelection.Damage, playerData);
        SetPlayerData(PlayerType.Basic, PlayerUpgradeSelection.Health, playerData);
        SetPlayerData(PlayerType.Basic, PlayerUpgradeSelection.Range, playerData);
        
        playerData.damage = (int)machineData.baseDamage;
        playerData.health = (int)machineData.health;
        playerData.range = (int)machineData.unitRange;
        SetPlayerData(PlayerType.Machine, PlayerUpgradeSelection.Damage, playerData);
        SetPlayerData(PlayerType.Machine, PlayerUpgradeSelection.Health, playerData);
        SetPlayerData(PlayerType.Machine, PlayerUpgradeSelection.Range, playerData);
        
        playerData.damage = (int)gunnerData.baseDamage;
        playerData.health = (int)gunnerData.health;
        playerData.range = (int)gunnerData.unitRange;
        SetPlayerData(PlayerType.Gunner, PlayerUpgradeSelection.Damage, playerData);
        SetPlayerData(PlayerType.Gunner, PlayerUpgradeSelection.Health, playerData);
        SetPlayerData(PlayerType.Gunner, PlayerUpgradeSelection.Range, playerData);
        
        playerData.damage = (int)bomberData.baseDamage;
        playerData.health = (int)bomberData.health;
        playerData.range = (int)bomberData.unitRange;
        SetPlayerData(PlayerType.Bomber, PlayerUpgradeSelection.Damage, playerData);
        SetPlayerData(PlayerType.Bomber, PlayerUpgradeSelection.Health, playerData);
        SetPlayerData(PlayerType.Bomber, PlayerUpgradeSelection.Range, playerData);
    }*/

    public enum PlayerType
    {
        Basic,
        Machine,
        Gunner,
        Bomber,
        Tank
    }
    public enum PlayerUpgradeSelection
    {
        Damage,
        Health,
        FireRate,
        Range
    }
    public struct PlayerData
    {
        public int damage;
        public int health;
        public int fireRate;
        public int range;
    }
    // create
    private static string GetPlayerPrefKey(PlayerType type, PlayerUpgradeSelection pus, string data)
    {
        return $"{type.ToString()}_Data_{pus}_{data}";
    } 
    
    //  veri yazma
    public static void SetPlayerData(PlayerType type, PlayerUpgradeSelection pus, PlayerData data)
    {
        PlayerPrefs.SetInt(GetPlayerPrefKey(type, pus, "Damage"), data.damage);
        PlayerPrefs.SetInt(GetPlayerPrefKey(type, pus, "Health"), data.health);
        PlayerPrefs.SetInt(GetPlayerPrefKey(type, pus, "FireRate"), data.fireRate);
        PlayerPrefs.SetInt(GetPlayerPrefKey(type, pus, "Range"), data.range);
    }

    // veri okuma
    public static PlayerData GetPlayerData(PlayerType type, PlayerUpgradeSelection pus)
    {
        PlayerData data = new PlayerData();
        data.damage = PlayerPrefs.GetInt(GetPlayerPrefKey(type, pus, "Damage"));
        data.health = PlayerPrefs.GetInt(GetPlayerPrefKey(type, pus, "Health"));
        data.fireRate = PlayerPrefs.GetInt(GetPlayerPrefKey(type, pus, "FireRate"));
        data.range = PlayerPrefs.GetInt(GetPlayerPrefKey(type, pus, "Range"));
        return data;
    }
    public static PlayerData GetAllPlayerData(PlayerType type)
    {
        PlayerData data = new PlayerData();
        data.damage = PlayerPrefs.GetInt(GetPlayerPrefKey(type, PlayerUpgradeSelection.Damage, "Damage"));
        data.health = PlayerPrefs.GetInt(GetPlayerPrefKey(type, PlayerUpgradeSelection.Health, "Health"));
        data.fireRate = PlayerPrefs.GetInt(GetPlayerPrefKey(type, PlayerUpgradeSelection.FireRate, "FireRate"));
        data.range = PlayerPrefs.GetInt(GetPlayerPrefKey(type, PlayerUpgradeSelection.Range, "Range"));
        return data;
    }
}