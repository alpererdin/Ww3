using System;
using UnityEngine;
using System.Collections;
using Data.ScriptableObjects;
using UnityEngine.UI;

namespace Managers
{
    public class UnitBtnController : MonoBehaviour
    {
        public Button button1,button2,button3;
        public SoldierData _dataSoldier;
        public SoldierData _dataMachine;
        public SoldierData _dataGunner;
        private float cooldownTimeSoldier =1f ; 
        private float cooldownTimeMachine = 2f;
        private float cooldownTimeGunner = 4f;
 
        private void Awake()
        {
            cooldownTimeSoldier = _dataSoldier.coolDownTime;
            cooldownTimeMachine = _dataMachine.coolDownTime;
            cooldownTimeGunner = _dataGunner.coolDownTime;
        }
        private void Start()
        {
            button1.onClick.AddListener(() => ActivateButton(button1, cooldownTimeSoldier));
            button2.onClick.AddListener(() => ActivateButton(button2, cooldownTimeMachine));
            button3.onClick.AddListener(() => ActivateButton(button3, cooldownTimeGunner));
        }
        private void ActivateButton(Button clickedButton, float cooldownTime)
        { 
            StopAllCoroutines();
            button1.image.fillAmount = 0f;
            button2.image.fillAmount = 0f;
            button3.image.fillAmount = 0f;
            StartCoroutine(ActivateButtonCoroutine(button1, cooldownTimeSoldier));
            StartCoroutine(ActivateButtonCoroutine(button2, cooldownTimeMachine));
            StartCoroutine(ActivateButtonCoroutine(button3, cooldownTimeGunner));
        }
        IEnumerator ActivateButtonCoroutine(Button button, float cooldownTime)
        {
            button.interactable = false;
            float elapsedTime = 0f;
            while (elapsedTime < cooldownTime)
            {
                elapsedTime += Time.deltaTime;
                button.image.fillAmount = elapsedTime / cooldownTime;
                yield return null;
            }
            button.interactable = true;
        } 
    }
}