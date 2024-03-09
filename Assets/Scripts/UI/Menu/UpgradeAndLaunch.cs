using System.Collections;
using System.Collections.Generic;
using Data.ScriptableObjects;
using Signals;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeAndLaunch : MonoBehaviour
{
     public GameObject panelBtnsPanel;
     public GameObject upgradesPanel;

     [Header("DATA")]
     public SoldierData _basicData;
     
     [Header("DATA")]
     public SoldierData _machineData;
     
     [Header("DATA")]
     public SoldierData _gunnerData;

     public void MenuBtn()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          
      //    SceneManager.LoadScene("menu");
     }

     public void StartBattle()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          SceneManager.LoadScene("TestScene");
     }
     public void onUpgradeMenu()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          panelBtnsPanel.SetActive(false);
          upgradesPanel.SetActive(true);
     }
     public void closeUpgradeMenu()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          panelBtnsPanel.SetActive(true);
          upgradesPanel.SetActive(false);
     }
     public void BasicDmgBtn()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          _basicData.baseDamage += (_basicData.baseDamage / 100) * 20;
     }  
     public void BasicRangeBtn()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          _basicData.unitRange += (_basicData.unitRange / 100)*7;
     }
     public void BasicFireBtn()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          _basicData.shootSpeed += (_basicData.shootSpeed / 100) ;
     }
     public void MachineDmgBtn()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          _machineData.baseDamage += (_machineData.baseDamage / 100) * 15;
     }  
     public void MachineRangeBtn()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          _machineData.unitRange += (_machineData.unitRange / 100)*5 ;
     }
     public void MachineFireBtn()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          _machineData.shootSpeed += (_machineData.shootSpeed / 100) ;
     }
     public void GunnerDmgBtn()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          _gunnerData.baseDamage += (_gunnerData.baseDamage / 100) *10;
     }  
     public void GunnerRangeBtn()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          _gunnerData.unitRange += (_gunnerData.unitRange / 100)*2 ;
     }
     public void GunnerFireBtn()
     {
          GameSignals.Instance.PlayOneShotEffect?.Invoke();
          _gunnerData.shootSpeed += (_gunnerData.shootSpeed / 100) ;
     }

}
