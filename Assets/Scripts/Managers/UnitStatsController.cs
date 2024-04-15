using System;
using System.Collections;
using System.Collections.Generic;
using Data.ScriptableObjects;
using DG.Tweening;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UnitStatsController : MonoBehaviour
{
    public TextMeshProUGUI titleTxt;

    public Slider damageSlider;
    public Slider HealthSlider;
    public Slider fireRateSlider;
    public Slider RangeSlider;

    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI FirerateText;
    public TextMeshProUGUI RangeText;

   
    public PlayerDataHandler.PlayerType type;
    private PlayerDataHandler.PlayerData takaDate;

    public float DamageVal;
    public float HealthVal;
    public float FireRateVal;
    public float RangeVal;
    
    public SoldierData basic;
    public SoldierData machine;
    public SoldierData gunner;
    public SoldierData bomber;
    public SoldierData tank;

    public RectTransform ImagePanel;

   // public RectTransform videoPanel;
   // public VideoPlayer videoPlayer;

   // public VideoClip basicVideo, machineVideo, gunnerVideo, bomberVideo, tankVideo;

  
    public void OnunitSelect(string tpyes)
    {
        AudioManager.Instance.PlaySFX("Click");
        ImagePanel.localScale = Vector3.zero;
        ImagePanel.DOScale(Vector3.one, .3f);

       // videoPanel.localScale = Vector3.zero;
      //  videoPanel.DOScale(Vector3.one, 1f);
        titleTxt.text = tpyes;
            if (tpyes == "Basic")
            {
                takaDate = PlayerDataHandler.GetAllPlayerData(PlayerDataHandler.PlayerType.Basic);
                DamageVal = takaDate.damage+basic.baseDamage;
                HealthVal = takaDate.health +basic.health;
                FireRateVal = takaDate.fireRate ;
                RangeVal = takaDate.range + basic.unitRange;
                DamageText.text = DamageVal.ToString();
                HealthText.text = HealthVal.ToString();
                FirerateText.text = (FireRateVal+10).ToString();
                RangeText.text = RangeVal.ToString();

                damageSlider.value = takaDate.damage;
                HealthSlider.value = takaDate.health;
                fireRateSlider.value = takaDate.fireRate;
                RangeSlider.value = takaDate.range;
                
             //   videoPlayer.clip = basicVideo;
            }
            else if (tpyes == "Machine")
            {
                takaDate = PlayerDataHandler.GetAllPlayerData( PlayerDataHandler.PlayerType.Machine);
                DamageVal = takaDate.damage + machine.baseDamage;
                HealthVal = takaDate.health + machine.health;
                FireRateVal = takaDate.fireRate;
                RangeVal = takaDate.range +machine.unitRange;
                DamageText.text = DamageVal.ToString();
                HealthText.text = HealthVal.ToString();
                FirerateText.text =  (FireRateVal+10).ToString();
                RangeText.text = RangeVal.ToString();
                
                damageSlider.value = takaDate.damage;
                HealthSlider.value = takaDate.health;
                fireRateSlider.value = takaDate.fireRate;
                RangeSlider.value = takaDate.range;
                
            //    videoPlayer.clip = machineVideo;
            }
            else if (tpyes == "Gunner")
            {
                takaDate = PlayerDataHandler.GetAllPlayerData(PlayerDataHandler.PlayerType.Gunner); 
                DamageVal = takaDate.damage + gunner.baseDamage;
                HealthVal = takaDate.health +gunner.health;
                FireRateVal = takaDate.fireRate;
                RangeVal = takaDate.range + gunner.unitRange;
                DamageText.text = DamageVal.ToString();
                HealthText.text = HealthVal.ToString();
                FirerateText.text = (FireRateVal+10).ToString();
                RangeText.text = RangeVal.ToString();
                
                damageSlider.value = takaDate.damage;
                HealthSlider.value = takaDate.health;
                fireRateSlider.value = takaDate.fireRate;
                RangeSlider.value = takaDate.range;
                
            //    videoPlayer.clip = gunnerVideo;
            }
            else if (tpyes == "Bomber")
            {
                takaDate = PlayerDataHandler.GetAllPlayerData(PlayerDataHandler.PlayerType.Bomber); 
                //DamageVal = takaDate.damage + gunner.baseDamage;
                HealthVal = takaDate.health +bomber.health;
                //FireRateVal = takaDate.fireRate;
               // RangeVal = takaDate.range + gunner.unitRange;
                DamageText.text = "NoN";
                HealthText.text = HealthVal.ToString();
                FirerateText.text ="NoN";
                RangeText.text = "NoN";
                
                damageSlider.value = 5;
                HealthSlider.value = takaDate.health;
                fireRateSlider.value =5;
                RangeSlider.value =5;
                
              //  videoPlayer.clip = bomberVideo;
            }
            else if (tpyes == "Tank")
            {
                takaDate = PlayerDataHandler.GetAllPlayerData(PlayerDataHandler.PlayerType.Tank); 
                //DamageVal = takaDate.damage + gunner.baseDamage;
                HealthVal = takaDate.health +tank.health;;
                //FireRateVal = takaDate.fireRate;
               // RangeVal = takaDate.range + gunner.unitRange;
                DamageText.text = "NoN";
                HealthText.text = HealthVal.ToString();
                FirerateText.text ="NoN";
                RangeText.text = "NoN";
                
                damageSlider.value = 5;
                HealthSlider.value = takaDate.health;
                fireRateSlider.value =5;
                RangeSlider.value =5;

                //videoPlayer.clip = tankVideo;
            }
            
    }
}
