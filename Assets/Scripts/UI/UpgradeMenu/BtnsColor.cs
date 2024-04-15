using System;
using System.Collections;
using System.Collections.Generic;
using Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnsColor : MonoBehaviour
{
    public List<Image> a;
    int z = 1;
    public TextMeshProUGUI costText;
    private UpgradeManager upManager;
    public PlayerDataHandler.PlayerType playerType; 
    public PlayerDataHandler.PlayerUpgradeSelection playerProperty;
    private PlayerDataHandler.PlayerData playerData;
    private int dataAmount;
    private void Update()
    {
        CheckMyBudget();
    }
    private void Start()
    { 
        playerData = PlayerDataHandler.GetPlayerData(playerType, playerProperty);
        if (playerProperty == PlayerDataHandler.PlayerUpgradeSelection.Damage)
        {
            dataAmount = playerData.damage;
        }
        else if (playerProperty == PlayerDataHandler.PlayerUpgradeSelection.Health)
        {
            dataAmount = playerData.health;
        }
        else if (playerProperty == PlayerDataHandler.PlayerUpgradeSelection.FireRate)
        {
            dataAmount = playerData.fireRate;
        }
        else if (playerProperty == PlayerDataHandler.PlayerUpgradeSelection.Range)
        {
            dataAmount = playerData.range;
        }
        upManager = FindObjectOfType<UpgradeManager>();
        if (upManager == null)
        {
            return;
        }
        CheckMyBudget();
        for (int j = 0; j < dataAmount; j++)
        {
            a[j].color=Color.green;
        }
        z = 2*dataAmount+1;
        costText.text = z.ToString();
    }
    public void paint3d()
    {
        GameSignals.Instance.PlayOneShotEffect?.Invoke();
        if (dataAmount>=5) return;
        for (int j = 0; j < dataAmount + 1; j++)
        {
            a[j].color = Color.green;
        }
        if (playerProperty == PlayerDataHandler.PlayerUpgradeSelection.Damage)
        {
            playerData.damage = dataAmount + 1;
            GameSignals.Instance.UpgradePanel?.Invoke(playerType,playerProperty,playerData.damage-1,playerData.damage);
            
        }
        else if (playerProperty == PlayerDataHandler.PlayerUpgradeSelection.Health)
        {
             playerData.health =dataAmount  + 1;
             GameSignals.Instance.UpgradePanel?.Invoke(playerType,playerProperty, playerData.health-1, playerData.health);
              
        }
        else if (playerProperty == PlayerDataHandler.PlayerUpgradeSelection.FireRate)
        {
            playerData.fireRate=dataAmount  + 1;
            GameSignals.Instance.UpgradePanel?.Invoke(playerType,playerProperty, playerData.fireRate-1, playerData.fireRate);
        }
        else if (playerProperty == PlayerDataHandler.PlayerUpgradeSelection.Range)
        {
             playerData.range=dataAmount + 1 ;
             GameSignals.Instance.UpgradePanel?.Invoke(playerType,playerProperty,playerData.range-1,playerData.range);
        }
        AudioManager.Instance.PlaySFX("Click");
        AudioManager.Instance.PlaySFX("upgrade");
        
        PlayerDataHandler.SetPlayerData(playerType, playerProperty, playerData);
        dataAmount++;
        LevelSignals.Instance.DecreaseLevelPoints?.Invoke(z);
        z = 2*dataAmount+1;
        costText.text = z == 25 ? "full" : z.ToString();
        CheckMyBudget();
    }
    private void CheckMyBudget()
    {
        if (upManager == null) 
        {
            return;
        }
        if (upManager.CurrentLevelPoints<z)
        {
          transform.GetComponent<Button>().interactable = false;
            costText.color=Color.red;
        }
        else
        {
          transform.GetComponent<Button>().interactable = true;
            costText.color=Color.green;
        }
    }
    private void OnEnable()
    {
        LevelSignals.Instance.OnChangedLevelPoints += CheckMyBudget;
    }
    private void OnDisable()
    {
        LevelSignals.Instance.OnChangedLevelPoints -= CheckMyBudget;
    }
}
