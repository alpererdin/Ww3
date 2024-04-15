using System;
using System.Collections.Generic;
using Signals;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public int CurrentLevelPoints;
    private void Awake()
    {
        CurrentLevelPoints += PlayerPrefs.GetInt("UpgradePoints", 0);
        UpdateLevelText();
    }
    private void OnEnable()
    {
        LevelSignals.Instance.AddLevelPoints += AddPoints;
        LevelSignals.Instance.DecreaseLevelPoints += DecreaseLevelPoints;
        ScoreBoardSignals.Instance.SetUpgradePoints += SetPoints;
    }
    private void OnDisable()
    {
        LevelSignals.Instance.AddLevelPoints -= AddPoints;
        LevelSignals.Instance.DecreaseLevelPoints -= DecreaseLevelPoints;
        ScoreBoardSignals.Instance.SetUpgradePoints -= SetPoints;
    }
   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddPoints(2);
        }
    }
    private void SetPoints()
    {
        CurrentLevelPoints = PlayerPrefs.GetInt("UpgradePoints", 0);
        CurrentLevelPoints++;
        PlayerPrefs.SetInt("UpgradePoints", CurrentLevelPoints);
        UpdateLevelText();
        LevelSignals.Instance.OnChangedLevelPoints?.Invoke();
    }
    private void AddPoints(int i)
    {
        CurrentLevelPoints += i;
        LevelSignals.Instance.OnChangedLevelPoints?.Invoke();
        UpdateLevelText();
    }
    private void DecreaseLevelPoints(int i)
    {
       
        CurrentLevelPoints -= i;
        PlayerPrefs.SetInt("UpgradePoints", CurrentLevelPoints); 
        LevelSignals.Instance.OnChangedLevelPoints?.Invoke();
        UpdateLevelText();
        LevelSignals.Instance.OnChangedLevelPoints?.Invoke();
    }
    private void UpdateLevelText()
    {
        levelText.text =  (CurrentLevelPoints).ToString();
    } 
    public void OnBtnOpenedBulletChecker()
    {
        AudioManager.Instance.PlaySFX("Click");
        LevelSignals.Instance.OnChangedLevelPoints?.Invoke();
    }
}