using System.Collections;
using System.Collections.Generic;
using Data.ScriptableObjects;
using Signals;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeAndLaunch : MonoBehaviour
{
     public void StartBattle()
     {
          AudioManager.Instance.PlaySFX("Click");
           AudioManager.Instance.PlayMusic("Loading");
          SceneManager.LoadScene("LoadingScene");
     }
}

