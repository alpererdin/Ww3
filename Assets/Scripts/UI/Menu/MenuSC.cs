using System.Collections;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSC : MonoBehaviour
{
   public GameObject continueBtn;
   public GameObject newBtn;
   public GameObject optionsBtn;
   public GameObject creditsBtn;

   public GameObject menuPanel;
   public GameObject optionsPanel;
   public GameObject upgradePanel;
   
   public GameObject beforeLaunchPanel;
   public GameObject upgradeMenuPanel;
   
   
   
   public void ContinueFunc()
   {
       GameSignals.Instance.PlayOneShotEffect?.Invoke();
       upgradePanel.SetActive(true);
       menuPanel.SetActive(false);
       optionsPanel.SetActive(false);
   }

   public void OptionsBtn()
   {
       GameSignals.Instance.PlayOneShotEffect?.Invoke();
       upgradePanel.SetActive(false);
       menuPanel.SetActive(false);
       optionsPanel.SetActive(true);
   }

   public void DoneInOptions()
   {
       GameSignals.Instance.PlayOneShotEffect?.Invoke();
       upgradePanel.SetActive(false);
       menuPanel.SetActive(true);
       optionsPanel.SetActive(false);
   }
   
   public void DoneInUpgradeMenu()
   {
       GameSignals.Instance.PlayOneShotEffect?.Invoke();
       upgradeMenuPanel.SetActive(false);
       beforeLaunchPanel.SetActive(true);
       
   }
}
