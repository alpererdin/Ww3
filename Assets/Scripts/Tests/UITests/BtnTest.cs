using System;
using System.Collections;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using UnityEngine.UI;

public class BtnTest : MonoBehaviour
{
    public Button BtnMenuBtn;
    public Button LockBtn;
    public Button CloseBtn;

    private bool rotated = false;
    private void Start()
    {
        CloseBtnMenu();
    }
    public void OpenBtnMenu()
    {
        //GameSignals.Instance.PlayOneShotEffect?.Invoke();
        LockBtn.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BtnMenuBtn.gameObject.SetActive(false);
    }
    public void CloseBtnMenu()
    {
        //GameSignals.Instance.PlayOneShotEffect?.Invoke();
        LockBtn.gameObject.SetActive(false);
        CloseBtn.gameObject.SetActive(false);
        BtnMenuBtn.gameObject.SetActive(true);
    }
    public void RotateLockBtn()
    {
        rotated = !rotated;
        LockBtn.transform.localRotation = Quaternion.Euler(0, 0, rotated ? 270f : 180f);
    }
}
