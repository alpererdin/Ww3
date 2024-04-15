using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Signals;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace UI.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        
        [SerializeField]  GameObject pauseMenu;
        [SerializeField] private RectTransform pausePanelRect , unitsPanel;
        
        [SerializeField] private float topPosY, middlePosY;
        [SerializeField] private float tweenDuration;
        
        public void HomeBtn()
        {
            AudioManager.Instance.PlaySFX("Click");
            Time.timeScale = 1f;
            SceneManager.LoadScene("LoadingMenuScene");
        }
        public void RestartBtn()
        {
            AudioManager.Instance.PlaySFX("Click");
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainScene");
        }

  
        public void OpenPanelFunc()
        {
            AudioManager.Instance.PlaySFX("Click");
            PausePanelIntro();
          //  AudioManager.Instance.PlaySFX("Click");
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        } 
        public async void ClosePanelFunc()
        {
            AudioManager.Instance.PlaySFX("Click");
            await PausePanelOutro();
            //AudioManager.Instance.PlaySFX("Click");
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void PausePanelIntro()
        {
            pausePanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
            unitsPanel.DOAnchorPosY(-250, tweenDuration).SetUpdate(true);
            

        }

        async Task PausePanelOutro()
        {
          await  pausePanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
          unitsPanel.DOAnchorPosY(-9, tweenDuration-0.4f).SetUpdate(true);
        }
    }
}