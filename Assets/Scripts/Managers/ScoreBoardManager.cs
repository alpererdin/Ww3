using System;
using System.Collections;
using System.Collections.Generic;
using Signals;
using Tests;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoardManager : MonoBehaviour
{
    public TextMeshProUGUI LoseOrWinTxt;
    
    public TextMeshProUGUI P_EnemiesKilledTxt;
    public TextMeshProUGUI P_UnitsDeployedTxt;
    public TextMeshProUGUI P_UnitsLostTxt;
    public TextMeshProUGUI P_TrenchesTakenTxt;
    public TextMeshProUGUI P_SupportUsedTxt;
    
    public TextMeshProUGUI E_EnemiesKilledTxt;
    public TextMeshProUGUI E_UnitsDeployedTxt;
    public TextMeshProUGUI E_UnitsLostTxt;
    public TextMeshProUGUI E_TrenchesTakenTxt;
   // public TextMeshProUGUI E_SupportUsedTxt;
   private int p_enemiesKilled;
   private int p_unitsDeployed;
   private int p_unitsLost;
   private int p_trenchesTaken;
   private int p_supportUsed;
   
   private int e_enemiesKilled;
   private int e_unitsDeployed;
   private int e_unitsLost;
   private int e_trenchesTaken;
   public GameObject Panel;

   public Button NextOrRestartBtn;

   public Sprite RestartImg;
   public Sprite NextImg;

    void Start()
    {
        p_enemiesKilled = 0;
        p_unitsDeployed= 0;
        p_unitsLost= 0;
        p_trenchesTaken= 0;
        p_supportUsed= 0;
        
        e_enemiesKilled = 0;
        e_unitsDeployed= 0;
        e_unitsLost= 0;
        e_trenchesTaken= 0;
    }
    private void OnEnable()
    {
        ScoreBoardSignals.Instance.OnKillEnemy += OnKillEnemy;
        ScoreBoardSignals.Instance.OnUnitDeploy += OnUnitDeploy;
        ScoreBoardSignals.Instance.OnUnitLost += OnUnitLost;
        ScoreBoardSignals.Instance.OnTrenchTaken += OnTrenchTaken;
        ScoreBoardSignals.Instance.OnSupportUsed += OnSupportUsed;
        ScoreBoardSignals.Instance.SetTexts += OnSetTexts;
        
        ScoreBoardSignals.Instance.OnEnemyKillEnemy += OnEnemyKillEnemy;
        ScoreBoardSignals.Instance.OnEnemyUnitDeploy += OnEnemyUnitDeploy;
        ScoreBoardSignals.Instance.OnEnemyUnitLost += OnEnemyUnitLost;
        ScoreBoardSignals.Instance.OnEnemyTrenchTaken += OnEnemyTrenchTaken;
    
    }
    private void OnSetTexts(byte i)
    {
        if (i==0)
        {
            
            LoseOrWinTxt.text = "Enemy Victory!";
            NextOrRestartBtn.image.sprite = RestartImg;
            NextOrRestartBtn.transform.GetChild(0).gameObject.GetComponent<Image>().sprite=RestartImg;
            NextOrRestartBtn.onClick.AddListener(Restart);
         
        }
        else
        {
            LoseOrWinTxt.text = "Company Victory!";
            NextOrRestartBtn.image.sprite = NextImg; 
            NextOrRestartBtn.transform.GetChild(0).gameObject.GetComponent<Image>().sprite=NextImg;
            NextOrRestartBtn.onClick.AddListener(Next);
    
        }
        
        P_EnemiesKilledTxt.text = p_enemiesKilled.ToString();
        P_UnitsDeployedTxt.text = p_unitsDeployed.ToString();
        P_UnitsLostTxt.text = p_unitsLost.ToString();
        P_TrenchesTakenTxt.text = p_trenchesTaken.ToString();
        P_SupportUsedTxt.text = p_supportUsed.ToString();
        
        e_enemiesKilled = p_unitsLost;
        e_unitsLost = p_enemiesKilled;
        
        E_EnemiesKilledTxt.text = e_enemiesKilled.ToString();
        E_UnitsDeployedTxt.text = e_unitsDeployed.ToString();
        E_UnitsLostTxt.text = e_unitsLost.ToString();
        E_TrenchesTakenTxt.text = e_trenchesTaken.ToString();
        
        
        Panel.SetActive(true);
    }

    private void Restart()
    {
        AudioManager.Instance.PlaySFX("Click");
        SceneManager.LoadScene("MainScene");
    }

    private void Next()
    {
        AudioManager.Instance.PlaySFX("Click");
        LevelTests.Instance.NextLvl();
        NextOrRestartBtn.interactable = false;
        Time.timeScale = 1;
        
    }

    private void OnEnemyKillEnemy()
    {
        e_enemiesKilled++;
    }
    private void OnEnemyUnitDeploy()
    {
        e_unitsDeployed++;
    }
    private void OnEnemyUnitLost()
    {
        e_unitsLost++;
    }
    private void OnEnemyTrenchTaken()
    {
        e_trenchesTaken++;
    }
    private void OnKillEnemy()
    {
        p_enemiesKilled++;
    }
     private void OnUnitDeploy()
     {
         p_unitsDeployed++;
     }
     private void OnUnitLost()
     {
         p_unitsLost++;
     }
     private void OnTrenchTaken()
     {
         p_trenchesTaken++;
     }
    private void OnSupportUsed()
    {
        p_supportUsed++;
    }
    
    private void OnDisable()
    {
        ScoreBoardSignals.Instance.OnKillEnemy -= OnKillEnemy;
        ScoreBoardSignals.Instance.OnUnitDeploy -= OnUnitDeploy;
        ScoreBoardSignals.Instance.OnUnitLost -= OnUnitLost;
        ScoreBoardSignals.Instance.OnTrenchTaken -= OnTrenchTaken;
        ScoreBoardSignals.Instance.OnSupportUsed -= OnSupportUsed;
        ScoreBoardSignals.Instance.SetTexts -= OnSetTexts;
        
        ScoreBoardSignals.Instance.OnEnemyKillEnemy -= OnEnemyKillEnemy;
        ScoreBoardSignals.Instance.OnEnemyUnitDeploy -= OnEnemyUnitDeploy;
        ScoreBoardSignals.Instance.OnEnemyUnitLost -= OnEnemyUnitLost;
        ScoreBoardSignals.Instance.OnEnemyTrenchTaken -= OnEnemyTrenchTaken;
    }
 
}
