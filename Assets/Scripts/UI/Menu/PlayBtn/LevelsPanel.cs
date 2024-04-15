using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class LevelsPanel : MonoBehaviour
{
    [SerializeField] private RectTransform OptionsPnl , mainMenuBtns;
    [SerializeField] private float topPosY, middlePosY;
    [SerializeField] private float tweenDuration;
    [SerializeField] private GameObject panel;
   
    [SerializeField] private CanvasGroup group;

   // [SerializeField] private GameObject MainMenupanel;
 
    public void OpenPanelFunc()
    {
        AudioManager.Instance.PlaySFX("Click");
        PausePanelIntro();
        panel.SetActive(true);
       // MainMenupanel.SetActive(false);
    } 
    public async void ClosePanelFunc()
    {
        AudioManager.Instance.PlaySFX("Click");
        await PausePanelOutro();
        panel.SetActive(false);
       // MainMenupanel.SetActive(true);
    }
    public void PausePanelIntro()
    {
        group.DOFade(0.90f, tweenDuration).SetUpdate(true);
        OptionsPnl.DOAnchorPosX(middlePosY, tweenDuration).SetUpdate(true);
        mainMenuBtns.DOAnchorPosX(-2500, tweenDuration).SetUpdate(true);
        
    }
    async Task PausePanelOutro()
    {
        group.DOFade(0, tweenDuration).SetUpdate(true);
        await  OptionsPnl.DOAnchorPosX(topPosY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
        
        mainMenuBtns.DOAnchorPosX(0, tweenDuration-0.5f).SetUpdate(true);
         
    }
}
