using System;
using UnityEngine;
using System.Collections;
using Data.ScriptableObjects;
using Signals;
using UnityEngine.UI;

namespace Managers
{
    public class UnitBtnController : MonoBehaviour
    {
        public Button button1,button2,button3,button4,button5;
        public SoldierData _dataSoldier;
        public SoldierData _dataMachine;
        public SoldierData _dataGunner;
        public SoldierData _dataBomber;
        public SoldierData _dataTank;
        private float cooldownTimeSoldier =1f ; 
        private float cooldownTimeMachine = 2f;
        private float cooldownTimeGunner = 4f;
        private float cooldownTimeBomber = 4f;
        private float cooldownTimeTank = 4f;

        private Image btnOne;
        private Image two;
        private Image three;
        private Image four;
        private Image five;
 
        private void Awake()
        {
            btnOne = button1.gameObject.transform.GetChild(0).GetComponent<Image>();
            two = button2.gameObject.transform.GetChild(0).GetComponent<Image>();
            three = button3.gameObject.transform.GetChild(0).GetComponent<Image>();
            four = button4.gameObject.transform.GetChild(0).GetComponent<Image>();
            five = button5.gameObject.transform.GetChild(0).GetComponent<Image>();
            
            cooldownTimeSoldier = _dataSoldier.coolDownTime;
            cooldownTimeMachine = _dataMachine.coolDownTime;
            cooldownTimeGunner = _dataGunner.coolDownTime;
            cooldownTimeBomber = _dataBomber.coolDownTime;
            cooldownTimeTank = _dataTank.coolDownTime;
        }
        private void Start()
        {
            btnOne.gameObject.SetActive(false);
            two.gameObject.SetActive(false);
            three.gameObject.SetActive(false);
            four.gameObject.SetActive(false);
            five.gameObject.SetActive(false);
            button1.onClick.AddListener(() => ActivateButton(button1, cooldownTimeSoldier));
            button2.onClick.AddListener(() => ActivateButton(button2, cooldownTimeMachine));
            button3.onClick.AddListener(() => ActivateButton(button3, cooldownTimeGunner));
            button4.onClick.AddListener(() => ActivateButton(button4, cooldownTimeBomber));
            button5.onClick.AddListener(() => ActivateButton(button5, cooldownTimeTank));
        }
        private void ActivateButton(Button clickedButton, float cooldownTime)
        { 
            StopAllCoroutines();
            button1.image.fillAmount = 0f;
            button2.image.fillAmount = 0f;
            button3.image.fillAmount = 0f;
            button4.image.fillAmount = 0f;
            button5.image.fillAmount = 0f;
            StartCoroutine(ActivateButtonCoroutine(button1, cooldownTimeSoldier));
            StartCoroutine(ActivateButtonCoroutine(button2, cooldownTimeMachine));
            StartCoroutine(ActivateButtonCoroutine(button3, cooldownTimeGunner));
            StartCoroutine(ActivateButtonCoroutine(button4, cooldownTimeBomber));
            StartCoroutine(ActivateButtonCoroutine(button5, cooldownTimeTank));
            
            btnOne.gameObject.SetActive(true);
            two.gameObject.SetActive(true);
            three.gameObject.SetActive(true);
            four.gameObject.SetActive(true);
            five.gameObject.SetActive(true);
            GameSignals.Instance.CreatedPlayerUnit?.Invoke();
          
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
            button.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        } 
    }
}