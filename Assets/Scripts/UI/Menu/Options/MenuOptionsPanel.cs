using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptionsPanel : MonoBehaviour
{
    [SerializeField] private RectTransform OptionsPnl;
    [SerializeField] private float topPosY, middlePosY;
    [SerializeField] private float tweenDuration;
    [SerializeField] private GameObject panel;
    [SerializeField] private CanvasGroup group;
    
    public void OpenPanelFunc()
    {
        AudioManager.Instance.PlaySFX("Click");
        PausePanelIntro();
        panel.SetActive(true);
    } 
    public async void ClosePanelFunc()
    {
        AudioManager.Instance.PlaySFX("Click");
        await PausePanelOutro();
        panel.SetActive(false);
    }
    public void PausePanelIntro()
    {
        group.DOFade(0.90f, tweenDuration).SetUpdate(true);
        OptionsPnl.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }
    async Task PausePanelOutro()
    {
        group.DOFade(0, tweenDuration).SetUpdate(true);
        await  OptionsPnl.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
    }
    
 
    
}
