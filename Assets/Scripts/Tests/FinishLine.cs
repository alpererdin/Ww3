using System;
using System.Collections;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public string Tag = "Player";
    private Collider col;
    public bool LastLevel;
    private void Awake()
    {
        col = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag(Tag))
      {
          if (Tag == "Player")
          {
              if (!LastLevel)
              {
                  ScoreBoardSignals.Instance.SetUpgradePoints.Invoke();
                  col.enabled = false;
                  // Debug.Log("Win panel");
                  ScoreBoardSignals.Instance.SetTexts.Invoke(1);
                  ScoreBoardSignals.Instance.ShowPanel.Invoke();
                  AudioManager.Instance.PlaySFX("win");
                  Time.timeScale = 0;
              }
              else
              {
                  AudioManager.Instance.PlaySFX("win");
                  SceneManager.LoadScene("LoadingMenuScene");
              }
             
          } 
          if (Tag == "Enemy")
          {
              col.enabled = false;
             // Debug.Log("Lose panel");
              ScoreBoardSignals.Instance.SetTexts.Invoke(0);
              ScoreBoardSignals.Instance.ShowPanel.Invoke();
              //    loooosee
              AudioManager.Instance.PlaySFX("lose");
              Time.timeScale = 0;
          }
      }
   }
}
