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
    public Button RunnBtn;
    
    private bool rotated = false;


    public GameObject btnMenuObj;
    public GameObject LockBtnObj;
    public GameObject CloseBtnObj;
    public GameObject RunnBtnObj;
    
   public void OpenBtnMenu()
    {
        AudioManager.Instance.PlaySFX("Click");
   
        /*LockBtn.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        BtnMenuBtn.gameObject.SetActive(false);
        RunnBtn.gameObject.SetActive(true);*/
        
        LockBtnObj.gameObject.SetActive(true);
        CloseBtnObj.gameObject.SetActive(true);
        btnMenuObj.gameObject.SetActive(false);
        RunnBtnObj.gameObject.SetActive(true);
        
        
    }
    public void CloseBtnMenu()
    {
        AudioManager.Instance.PlaySFX("Click");

        /*LockBtn.gameObject.SetActive(false);
        CloseBtn.gameObject.SetActive(false);
        BtnMenuBtn.gameObject.SetActive(true);
        RunnBtn.gameObject.SetActive(false);*/
        
        LockBtnObj.gameObject.SetActive(false);
        CloseBtnObj.gameObject.SetActive(false);
        btnMenuObj.gameObject.SetActive(true);
        RunnBtnObj.gameObject.SetActive(false);
    }
    public void RotateLockBtn()
    {
        AudioManager.Instance.PlaySFX("Click");

        rotated = !rotated;
        LockBtn.transform.localRotation = Quaternion.Euler(0, 0, rotated ? 90f :0f);
    }
    public void InvokeButtons()
    {
        AudioManager.Instance.PlaySFX("whistle");
        CloseBtnMenu();
        Transform a = transform.GetChild(0).GetChild(0);
        int childCount = a.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = a.transform.GetChild(i);
            Button childButton = child.GetComponent<Button>();
            if (childButton != null)
            {
                childButton.onClick.Invoke();
            }
        }
    }
}
