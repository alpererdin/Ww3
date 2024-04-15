using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class UpgradeMenuOpennings : MonoBehaviour
{
    [SerializeField] private RectTransform UpgradePanelRect;
    [SerializeField] private float topPosY, middlePosY;
    [SerializeField] private float tweenDuration;
    public void OpenPanelFunc()
    {
        PausePanelIntro();
    } 
    public async void ClosePanelFunc()
    {
        await PausePanelOutro();
    }
    public void PausePanelIntro()
    {
        UpgradePanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }
    async Task PausePanelOutro()
    {
        await  UpgradePanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
    }
}
