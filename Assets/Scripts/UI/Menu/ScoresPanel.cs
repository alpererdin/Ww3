using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Signals;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
public class ScoresPanel : MonoBehaviour
{
    [SerializeField]  GameObject pauseMenu;
          [SerializeField] private RectTransform scorePanelRect , unitsPanel;
          
          [SerializeField] private float topPosY, middlePosY;
          [SerializeField] private float tweenDuration;

          private void OnEnable()
          {
              ScoreBoardSignals.Instance.ShowPanel += OpenPanelFunc;
          } 
          private void OnDisable()
          {
              ScoreBoardSignals.Instance.ShowPanel -= OpenPanelFunc;
             // ClosePanelFunc();
          }

          public void OpenPanelFunc()
          {
              PausePanelIntro();
           //   pauseMenu.SetActive(true);
          } 
          public async void ClosePanelFunc()
          {
              await PausePanelOutro();
           //   pauseMenu.SetActive(false);
          }
  
          public void PausePanelIntro()
          {
              scorePanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
              unitsPanel.DOAnchorPosY(-250, tweenDuration).SetUpdate(true);
          }
          async Task PausePanelOutro()
          {
            await  scorePanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
            unitsPanel.DOAnchorPosY(-9, tweenDuration-0.4f).SetUpdate(true);
          }
}
